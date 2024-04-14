using UnityEngine;

namespace Totem
{
    public class Animations : MonoBehaviour
    {
        private Animator animator;

        public Health health;

        void Start()
        {
            health.Hurt += OnHurt;
            health.Died += OnDie;

            animator = GetComponent<Animator>();
        }

        private void OnHurt()
        {
            animator.SetTrigger("hurt");
        }

        private void OnDie()
        {
            animator.SetBool("isDead", true);

            health.Hurt -= OnHurt;
            health.Died -= OnDie;
        }
    }
}
