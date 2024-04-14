using Random = System.Random;
using UnityEngine;

namespace Spawner
{
    public class SpawnersBrain : MonoBehaviour
    {
        public GameManagement.GameManager gameManager;
        public GameManagement.WavesManager wavesManager;

        public GameObject enemyObject;

        private SpawnPoint[] spawnPoints;
        private Random randomGen = new Random();

        private int enemiesToSpawn = 0;

        public float spawnDelay;
        private float currentSpawnDelay = 0.0f;

        void Start()
        {
            gameManager.FinishedGame += OnFinishGame;
            wavesManager.StartedWaveEnemies += OnStartWaveEnemies;

            currentSpawnDelay = spawnDelay;

            spawnPoints = GetComponentsInChildren<SpawnPoint>();
        }

        void FixedUpdate()
        {
            if (enemiesToSpawn == 0)
                return;

            if (currentSpawnDelay < spawnDelay)
            {
                currentSpawnDelay += Time.fixedDeltaTime;
            }
            else
            {
                spawnPoints[randomGen.Next(0, spawnPoints.Length)].SpawnEnemy(enemyObject);
                --enemiesToSpawn;
                currentSpawnDelay = 0.0f;
            }
        }

        private void OnFinishGame()
        {
            gameManager.FinishedGame -= OnFinishGame;
            wavesManager.StartedWaveEnemies -= OnStartWaveEnemies;
        }

        private void OnStartWaveEnemies(int enemiesNumber)
        {
            enemiesToSpawn = enemiesNumber;
        }
    }
}
