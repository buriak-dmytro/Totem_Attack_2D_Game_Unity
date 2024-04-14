using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using TMPro;
using UnityEngine;

namespace Interface
{
    public class SaveLeaders : MonoBehaviour
    {
        public GameManagement.SessionStatus sessionStatus;
        public TextMeshProUGUI nameTMP;

        public void SaveData()
        {
            float time = sessionStatus.PlayTime;

            int minutes = (int)(time / 60);
            int seconds = (int)(time % 60);
            int milliseconds = (int)(time % 1 * 100 % 100);

            string timeStr = $"{minutes:00}:{seconds:00}:{milliseconds:00}";

            SessionStatusDTO sessionStatusDTO = 
                new SessionStatusDTO(
                    nameTMP.text,
                    sessionStatus.Points,
                    sessionStatus.Waves,
                    sessionStatus.Enemies,
                    timeStr);

            //

            string path = Application.persistentDataPath + "/leaders.json";

            if (!File.Exists(path))
                File.Create(path).Dispose();

            FileStream fileStream = new FileStream(path, FileMode.Open);
            StreamReader fileReader = new StreamReader(fileStream);
            string json = fileReader.ReadToEnd();
            fileReader.Close();
            fileStream.Close();
            
            Debug.Log(json);

            List<SessionStatusDTO> leadersList;
            if (string.IsNullOrEmpty(json))
            {
                leadersList = new List<SessionStatusDTO>();
                leadersList.Add(sessionStatusDTO);
            }
            else
            {
                leadersList = JsonConvert.DeserializeObject<List<SessionStatusDTO>>(json);

                int indexPlace = 0;
                bool isFoundPlace = false;
                for (int i = 0; i < leadersList.Count && isFoundPlace; i++)
                {
                    if (sessionStatusDTO.points < leadersList[i].points)
                    {
                        isFoundPlace = true;
                    }
                    indexPlace = i;
                }
                if (isFoundPlace)
                {
                    leadersList.Insert(indexPlace, sessionStatusDTO);
                    if (leadersList.Count > 10)
                    {
                        leadersList.RemoveAt(10);
                    }
                }
                else
                {
                    indexPlace++;
                    if (indexPlace < 10)
                    {
                        leadersList.Insert(indexPlace, sessionStatusDTO);
                    }
                }
            }
            json = JsonConvert.SerializeObject(leadersList);

            Debug.Log(json);

            fileStream = new FileStream(path, FileMode.Truncate);
            StreamWriter fileWriter = new StreamWriter(fileStream);
            fileWriter.Write(json);
            fileWriter.Close();
            fileStream.Close();
        }
    }
}
