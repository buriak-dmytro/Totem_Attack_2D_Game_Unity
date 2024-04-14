using System;
using UnityEngine;

namespace Totem
{
    public class Health : MonoBehaviour
    {
        public event Action TookHealth;

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
            TookHealth?.Invoke();
        }

        public void TakeDamage(float points)
        {
            if (isDead)
                return;

            if (isInvincible)
                return;

            currentHealth = Mathf.Clamp(currentHealth - points, 0.0f, maxHealth);
            TookHealth?.Invoke();
            Hurt?.Invoke();
            isInvincible = true;

            if (currentHealth == 0.0f)
            {
                isDead = true;
                Died?.Invoke();
            }
        }

        private void OnDie()
        {
            Died -= OnDie;
        }
    }
}
