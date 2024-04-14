using UnityEngine;

namespace BoostsManagement
{
    public class HealthPlayerBoost : Boost
    {
        private Player.Health health;

        void Start()
        {
            health = 
                GameObject
                .FindWithTag("Player")
                .GetComponent<Player.Health>();
        }

        public override void Collect()
        {
            health.TakeHeal(randomGen.Next(1, 5) * 10);
        }
    }
}
