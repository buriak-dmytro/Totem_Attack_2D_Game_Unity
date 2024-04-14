using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using TMPro;
using UnityEngine;

namespace Interface
{
    public class LoadLeaders : MonoBehaviour
    {
        public GameObject contentHolder;

        private bool isLoadedLeaders = false;

        public void LoadFirstTime()
        {
            if (isLoadedLeaders)
                return;

            isLoadedLeaders = true;
            LoadData();
        }

        private void LoadData()
        {
            string path = Application.persistentDataPath + "/leaders.json";

            if (!File.Exists(path))
                return;

            FileStream fileStream = new FileStream(path, FileMode.Open);
            StreamReader fileReader = new StreamReader(fileStream);
            string json = fileReader.ReadToEnd();
            fileReader.Close();
            fileStream.Close();

            if (string.IsNullOrEmpty(json))
                return;

            List<SessionStatusDTO> leadersList = JsonConvert.DeserializeObject<List<SessionStatusDTO>>(json);

            for (int i = 0; i < leadersList.Count; i++)
            {
                GameObject leaderGameObject = contentHolder.transform.GetChild(i).gameObject;

                leaderGameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = (i + 1).ToString();
                leaderGameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = leadersList[i].name.Length > 10 ? leadersList[i].name[..7] + "..." : leadersList[i].name;
                leaderGameObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = leadersList[i].points.ToString();
                leaderGameObject.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = leadersList[i].waves.ToString();
                leaderGameObject.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = leadersList[i].enemies.ToString();
                leaderGameObject.transform.GetChild(5).GetComponent<TextMeshProUGUI>().text = leadersList[i].playTime;
            }
        }
    }
}
