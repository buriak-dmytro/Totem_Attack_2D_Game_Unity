using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Interface
{
    public class GameplayInterface : MonoBehaviour
    {
        public Totem.Health healthTotem;
        public Player.Health healthPlayer;
        public GameManagement.SessionStatus sessionStatus;
        public GameManagement.WavesManager waveManager;

        public Slider healthTotemSlider;
        public Slider healthPlayerSlider;

        public TextMeshProUGUI pointsTMP;
        public TextMeshProUGUI waveTMP;
        public TextMeshProUGUI enemiesTMP;

        public TextMeshProUGUI waveKeyPointTMP;
        public float textWaveDelay;
        private float currentDelay = 0.0f;
        private bool isWaitingDelay = false;

        void Start()
        {
            healthTotem.TookHealth += OnTakeHealthTotem;

            healthPlayer.TookHealth += OnTakeHealthPlayer;

            sessionStatus.TookPoints += OnTakePoints;
            waveManager.StartedWaveNumber += OnStartWaveNumber;
            sessionStatus.TookEnemy += OnTakeEnemy;

            waveManager.FinishedWaveNumber += OnFinishWaveNumber;
        }

        void Update()
        {
            if (!isWaitingDelay)
                return;

            if (currentDelay < textWaveDelay)
            {
                currentDelay += Time.deltaTime;
            }
            else
            {
                waveKeyPointTMP.text = "";
                isWaitingDelay = false;
                currentDelay = 0.0f;
            }
        }

        private void OnTakeHealthTotem()
        {
            healthTotemSlider.value = healthTotem.CurrentHealth / healthTotem.MaxHealth;
        }

        private void OnTakeHealthPlayer()
        {
            healthPlayerSlider.value = healthPlayer.CurrentHealth / healthPlayer.MaxHealth;
        }

        private void OnTakePoints()
        {
            pointsTMP.text = sessionStatus.Points.ToString();
        }

        private void OnStartWaveNumber(int waveNumber)
        {
            waveTMP.text = waveNumber.ToString();

            waveKeyPointTMP.text = $"Wave {waveNumber} started!";
            isWaitingDelay = true;
        }

        private void OnFinishWaveNumber(int waveNumber)
        {
            waveKeyPointTMP.text = $"Wave {waveNumber} is cleared!";
            isWaitingDelay = true;
        }

        private void OnTakeEnemy()
        {
            enemiesTMP.text = sessionStatus.Enemies.ToString();
        }
    }
}
