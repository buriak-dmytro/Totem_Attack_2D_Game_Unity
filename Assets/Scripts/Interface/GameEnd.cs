using UnityEngine;

namespace Interface
{
    public class GameEnd : MonoBehaviour
    {
        public GameManagement.GameManager gameManager;
        public SessionResults sessionResults;
        public NextCanvas nextCanvas;

        void Start()
        {
            gameManager.FinishedGame += OnFinishGame;
        }

        private void OnFinishGame()
        {
            sessionResults.FillSessionResults();
            nextCanvas.OpenCanvas();
        }
    }
}
