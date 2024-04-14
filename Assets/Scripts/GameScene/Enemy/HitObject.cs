using System;
using UnityEngine;

namespace Enemy
{
    public class HitObject : MonoBehaviour
    {
        public event Action InRangeTarget; 
        public event Action OutRangeTarget;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            GameObject gameObject = collision.gameObject;
            if (gameObject.CompareTag("Player") ||
                gameObject.CompareTag("Totem"))
            {
                InRangeTarget?.Invoke();
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            GameObject gameObject = collision.gameObject;
            if (gameObject.CompareTag("Player") ||
                gameObject.CompareTag("Totem"))
            {
                OutRangeTarget?.Invoke();
            }
        }
    }
}
