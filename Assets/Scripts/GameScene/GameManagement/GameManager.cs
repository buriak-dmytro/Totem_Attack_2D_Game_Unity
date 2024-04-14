using System;
using UnityEngine;

namespace GameManagement
{
    public class GameManager : MonoBehaviour
    {
        public event Action StartedGame;
        public event Action FinishedGame;

        public Player.AnimationHurtInvoker animationHurtInvokerPlayer;
        public Totem.AnimationHurtInvoker animationHurtInvokerTotem;

        bool isFinishedGame = false;

        void Start()
        {
            animationHurtInvokerPlayer.FinishedDie += OnFinishDie;
            animationHurtInvokerTotem.FinishedDie += OnFinishDie;

            OnStartGame(); // test
        }

        void Update()
        {
        
        }

        private void OnFinishDie()
        {
            if (isFinishedGame)
                return;

            isFinishedGame = true;

            Time.timeScale = 0.0f;
            
            FinishedGame?.Invoke();
        }

        private void OnStartGame()
        {
            StartedGame?.Invoke();
        }


    }
}
