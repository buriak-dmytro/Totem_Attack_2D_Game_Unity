using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Interface
{
    public class SaveLoadSettings : MonoBehaviour
    {
        public Slider slidereSFX;
        public Slider sliderMusic;

        private void Start()
        {
            LoadData();
            SceneManager.sceneLoaded += OnSceneLoad;
        }

        private void OnSceneLoad(Scene arg0, LoadSceneMode arg1)
        {
            LoadData();
        }

        public void SaveData()
        {
            float sfxVolume = slidereSFX.value;
            float musicVolume = sliderMusic.value;

            SettingsDTO settings = new SettingsDTO(sfxVolume, musicVolume);
            string json = JsonUtility.ToJson(settings);

            string path = Application.persistentDataPath + "/settings.json";

            if (!File.Exists(path))
                File.Create(path).Dispose();

            FileStream fileStream = new FileStream(path, FileMode.Truncate);
            StreamWriter fileWriter = new StreamWriter(fileStream);
            fileWriter.Write(json);
            fileWriter.Close();
            fileStream.Close();
        }

        public void LoadData()
        {
            string path = Application.persistentDataPath + "/settings.json";

            if (!File.Exists(path))
                return;

            FileStream fileStream = new FileStream(path, FileMode.Open);
            StreamReader fileReader = new StreamReader(fileStream);
            string json = fileReader.ReadToEnd();
            fileReader.Close();
            fileStream.Close();

            if (string.IsNullOrEmpty(json))
                return;

            SettingsDTO settings = JsonUtility.FromJson<SettingsDTO>(json);

            slidereSFX.value = settings.volumeSFX;
            sliderMusic.value = settings.volumeMusic;
        }
    }
}
