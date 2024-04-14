using Random = System.Random;
using UnityEngine;

namespace BoostsManagement
{
    public abstract class Boost : MonoBehaviour
    {
        protected static Random randomGen = new Random();

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("BoostCollectorPlayer"))
            {
                Collect();
                Destroy(gameObject);
            }
        }

        public abstract void Collect();
    }
}
