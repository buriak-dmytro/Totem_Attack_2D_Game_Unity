using UnityEngine;

namespace BoostsManagement
{
    public class HealthTotemBoost : Boost
    {
        private Totem.Health health;

        void Start()
        {
            health =
                GameObject
                .FindWithTag("Totem")
                .GetComponent<Totem.Health>();
        }

        public override void Collect()
        {
            health.TakeHeal(randomGen.Next(1, 5) * 20);
        }
    }
}
