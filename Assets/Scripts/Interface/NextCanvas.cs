using UnityEngine;

namespace Interface
{
    public class NextCanvas : MonoBehaviour
    {
        public Canvas canvasToHide;
        public Canvas canvasToOpen;

        public void OpenCanvas()
        {
            canvasToHide.gameObject.SetActive(false);
            canvasToOpen.gameObject.SetActive(true);
        }
    }
}
