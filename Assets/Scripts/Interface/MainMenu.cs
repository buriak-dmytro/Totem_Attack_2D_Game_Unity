using UnityEngine;
using UnityEngine.SceneManagement;

namespace Interface
{
    public class MainMenu : MonoBehaviour
    {
        public void GoToMainMenu()
        {
            SceneManager.LoadScene("MenuScene");
            //SceneManager.UnloadSceneAsync("GameScene");
        }
    }
}
