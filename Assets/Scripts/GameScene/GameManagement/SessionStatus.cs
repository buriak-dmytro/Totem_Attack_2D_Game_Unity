using System;
using UnityEngine;

namespace GameManagement
{
    public class SessionStatus : MonoBehaviour
    {
        public event Action TookPoints;
        public event Action TookEnemy;

        public GameManager gameManager;
        public WavesManager wavesManager;

        private const int POINTS_FOR_ENEMY = 50;
        private const int POINTS_FOR_WAVE = 200;

        private int points;
        public int Points { get { return points; } } // for UI mb

        private int waves;
        public int Waves { get { return waves; } } // for UI mb

        private int enemies;
        public int Enemies { get { return enemies; } } // for UI mb

        private float playTime;
        private bool isTimeCounting = false;
        public float PlayTime { get { return playTime; } } // for UI mb

        void Start()
        {
            Enemy.Health.NotifiedDeath += TakePointsForEnemy;
            wavesManager.FinishedWaveNumber += TakeWave;
            Enemy.Health.NotifiedDeath += TakeEnemies;

            gameManager.StartedGame += OnStartGame;
            gameManager.FinishedGame += OnFinishGame;
        }

        private void FixedUpdate()
        {
            if (isTimeCounting)
            {
                playTime += Time.fixedDeltaTime;
            }
        }

        private void TakePointsForEnemy()
        {
            points += POINTS_FOR_ENEMY;
            TookPoints?.Invoke();
        }

        public void TakePoints(int value)
        {
            points += value;
            TookPoints?.Invoke();
        }

        private void TakeWave(int value)
        {
            waves = value;
            points += POINTS_FOR_WAVE;
        }

        private void TakeEnemies()
        {
            enemies = enemies + 1;
            TookEnemy?.Invoke();
        }

        private void OnStartGame()
        {
            isTimeCounting = true;
        }

        private void OnFinishGame()
        {
            isTimeCounting = false;
        }
    }
}
