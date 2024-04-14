using UnityEngine;

namespace BoostsManagement
{
    public class DamageWeaponPlayerBoost : Boost
    {
        private Player.Weapon weapon;

        void Start()
        {
            weapon =
                GameObject
                .FindWithTag("PlayerWeapon")
                .GetComponent<Player.Weapon>();
        }

        public override void Collect()
        {
            weapon.IncreaseDamage(randomGen.Next(1, 6));
        }
    }
}
