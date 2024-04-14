using System;
using UnityEngine;

namespace Enemy
{
    public class FollowObject : MonoBehaviour
    {
        public event Action<GameObject> Followed;
        public event Action Unfollowed;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            GameObject gameObject = collision.gameObject;
            if (gameObject.CompareTag("Player"))
            {
                Followed?.Invoke(gameObject.transform.parent.gameObject);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            GameObject gameObject = collision.gameObject;
            if (gameObject.CompareTag("Player"))
            {
                Unfollowed?.Invoke();
            }
        }
    }
}
