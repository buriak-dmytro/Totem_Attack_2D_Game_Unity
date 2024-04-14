using Random = System.Random;
using UnityEngine;
using System.Collections.Generic;

namespace BoostsManagement
{
    public class BoostsDropManager : MonoBehaviour
    {
        public List<Boost> boosts;

        [Range(0, 100)]
        public int boostDropChance;

        private Random randomGen = new Random();

        void Start()
        {
            Enemy.Health.NotifiedDeathPosition += DropBoost;
        }

        private void DropBoost(Vector2 position)
        {
            if (randomGen.Next(0, 101) < boostDropChance - 1)
            {
                Instantiate(
                    boosts[randomGen.Next(0, boosts.Count)],
                    position,
                    Quaternion.identity
                );
            }
        }
    }
}
