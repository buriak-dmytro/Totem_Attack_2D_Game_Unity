using TMPro;
using UnityEngine;

namespace Interface
{
    public class SessionResults : MonoBehaviour
    {
        public GameManagement.SessionStatus sessionStatus;
        public GameObject resultsPanel;

        public void FillSessionResults()
        {
            float time = sessionStatus.PlayTime;

            int minutes = (int)(time / 60);
            int seconds = (int)(time % 60);
            int milliseconds = (int)(time % 1 * 100 % 100);

            string timeStr = $"{minutes:00}:{seconds:00}:{milliseconds:00}";

            resultsPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = sessionStatus.Points.ToString();
            resultsPanel.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = sessionStatus.Waves.ToString();
            resultsPanel.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = sessionStatus.Enemies.ToString();
            resultsPanel.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = timeStr;
        }
    }
}
