using System;
using UnityEngine;

namespace Enemy
{
    public class Health : MonoBehaviour
    {
        public AnimationAttackInvoker animationAttackInvoker;
        private bool isAttacking = false;
        
        public static event Action NotifiedDeath;
        public static event Action<Vector2> NotifiedDeathPosition;
        public event Action Died;
        public event Action Hurt;

        [SerializeField] private float maxHealth;
        public float MaxHealth { get { return maxHealth; } } // for UI mb

        private float currentHealth;
        public float CurrentHealth { get { return currentHealth; } } // for UI mb

        private bool isDead = false;

        private bool isInvincible = false;
        public float noDamageTime;
        private float currentNoDamageTime = 0.0f;

        void Start()
        {
            animationAttackInvoker.StartedAttack += StartAttack;
            animationAttackInvoker.FinishedAttack += FinishAttack;

            Died += OnDie;

            currentHealth = maxHealth;
        }

        void FixedUpdate()
        {
            if (isInvincible)
            {
                if (currentNoDamageTime < noDamageTime)
                    currentNoDamageTime += Time.fixedDeltaTime;
                else
                {
                    isInvincible = false;
                    currentNoDamageTime = 0.0f;
                }
            }
        }

        public void TakeHeal(float points)
        {
            currentHealth = Mathf.Clamp(currentHealth + points, 0.0f, maxHealth);
        }

        public void TakeDamage(float points)
        {
            if (isDead)
                return;

            if (isInvincible)
                return;

            if (isAttacking)
                return;

            currentHealth = Mathf.Clamp(currentHealth - points, 0.0f, maxHealth);
            Hurt?.Invoke();
            isInvincible = true;

            if (currentHealth == 0.0f)
            {
                isDead = true;
                Died?.Invoke();
                NotifiedDeath?.Invoke();
                NotifiedDeathPosition.Invoke(transform.position);
            }
        }

        private void StartAttack()
        {
            isAttacking = true;
        }

        private void FinishAttack()
        {
            isAttacking = false;
        }

        private void OnDie()
        {
            animationAttackInvoker.StartedAttack -= StartAttack;
            animationAttackInvoker.FinishedAttack -= FinishAttack;

            Died -= OnDie;
        }
    }
}