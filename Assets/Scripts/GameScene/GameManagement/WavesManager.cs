using System;
using UnityEngine;

namespace GameManagement
{
    public class WavesManager : MonoBehaviour
    {
        public event Action<int> StartedWaveNumber;
        public event Action<int> FinishedWaveNumber;

        public event Action<int> StartedWaveEnemies;

        public GameManager gameManager;

        public float waveDelay;
        private float currentWaveDelay = 0.0f;
        private bool isWaitingDelay = false;

        private int waveEnemies;
        private int waveEnemiesDeath;

        private int waveNumber = 0;
        public int WaveNumber { get; private set; }
        
        void Start()
        {
            gameManager.StartedGame += OnStartGame;
            gameManager.FinishedGame += OnFinishGame;

            Enemy.Health.NotifiedDeath += OnNotifyDeath;
        }

        void FixedUpdate()
        {
            if (!isWaitingDelay)
                return;

            if (currentWaveDelay < waveDelay)
            {
                currentWaveDelay += Time.fixedDeltaTime;
            }
            else
            {
                isWaitingDelay = false;
                currentWaveDelay = 0.0f;
                StartWave();
            }
        }

        private void StartWave()
        {
            waveNumber = waveNumber + 1;
            waveEnemies = waveNumber * 5;
            waveEnemiesDeath = 0;

            StartedWaveNumber?.Invoke(waveNumber);
            Debug.Log($"Wave #{waveNumber} is started");

            StartedWaveEnemies?.Invoke(waveEnemies);
        }

        private void OnStartGame()
        {
            isWaitingDelay = true;
        }

        private void OnFinishGame()
        {
            gameManager.StartedGame -= OnStartGame;
            gameManager.FinishedGame -= OnFinishGame;

            Enemy.Health.NotifiedDeath -= OnNotifyDeath;
        }

        private void OnNotifyDeath()
        {
            waveEnemiesDeath = waveEnemiesDeath + 1;

            if (waveEnemiesDeath == waveEnemies)
            {
                FinishedWaveNumber?.Invoke(waveNumber);
                Debug.Log($"Wave #{waveNumber} is cleared");

                isWaitingDelay = true;
            }
        }
    }
}
