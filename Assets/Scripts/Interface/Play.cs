using UnityEngine;
using UnityEngine.SceneManagement;

namespace Interface
{
    public class Play : MonoBehaviour
    {
        public void PlayGame()
        {
            SceneManager.LoadScene("GameScene");
            //SceneManager.UnloadSceneAsync("MenuScene");

            Time.timeScale = 1.0f;
        }

        public void PlayAgainGame()
        {
            SceneManager.LoadScene("GameScene");

            Time.timeScale = 1.0f;
        }
    }
}
