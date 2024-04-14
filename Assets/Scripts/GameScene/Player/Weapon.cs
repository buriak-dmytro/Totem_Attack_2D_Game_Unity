using UnityEngine;

namespace Player
{
    public class Weapon : MonoBehaviour
    {
        public AnimationAttackInvoker animationAttackInvoker;

        public Health health;

        private BoxCollider2D bc2D;

        public float damage;

        void Start()
        {
            animationAttackInvoker.StartedAttack += StartAttack;
            animationAttackInvoker.FinishedAttack += FinishAttack;

            health.Died += OnDie;

            bc2D = GetComponent<BoxCollider2D>();
        }

        public void IncreaseDamage(float points)
        {
            damage += points;
        }

        private void OnFire()
        {
            // no sense for this method
            // (fire is managed by attack animation)
            // (two methods below is triggered by animation)
        }

        public void StartAttack()
        {
            bc2D.enabled = true;
        }

        public void FinishAttack()
        {
            bc2D.enabled = false;
        }

        private void OnDie()
        {
            animationAttackInvoker.StartedAttack -= StartAttack;
            animationAttackInvoker.FinishedAttack -= FinishAttack;

            health.Died -= OnDie;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            GameObject gameObject = collision.gameObject;
            if (gameObject.CompareTag("Enemy"))
            {
                gameObject.GetComponent<Enemy.Health>().TakeDamage(damage);

                OnTriggerExit2D(collision);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            
        }
    }
}
