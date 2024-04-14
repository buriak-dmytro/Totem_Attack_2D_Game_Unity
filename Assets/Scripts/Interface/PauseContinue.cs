using UnityEngine;

namespace Interface
{
    public class PauseContinue : MonoBehaviour
    {
        public void PauseGame()
        {
            Time.timeScale = 0.0f;
        }

        public void ContinueGame()
        {
            Time.timeScale = 1.0f;
        }
    }
}
