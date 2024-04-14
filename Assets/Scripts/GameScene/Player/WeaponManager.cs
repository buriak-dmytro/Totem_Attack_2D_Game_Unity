using UnityEngine;

namespace Player
{
    public class WeaponManager : MonoBehaviour
    {
        public Input input;

        public Health health;

        void Start()
        {
            input.Moved += OnMove;

            health.Died += OnDie;
        }

        private void OnMove(Vector2 move)
        {
            float rotationZ = 0.0f;

            if (move.x > 0.71 && (move.y > -0.71 && move.y < 0.71))
            {
                rotationZ = -90.0f;
            }
            else if ((move.x > -0.71 && move.x < 0.71) && move.y > 0.71)
            {
                rotationZ = 0.0f;
            }

            else if (move.x < -0.71 && (move.y > -0.71 && move.y < 0.71))
            {
                rotationZ = 90.0f;
            }

            else if ((move.x > -0.71 && move.x < 0.71) && move.y < -0.71)
            {
                rotationZ = 180.0f;
            }

            transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        }

        private void OnDie()
        {
            input.Moved -= OnMove;

            health.Died -= OnDie;
        }
    }
}
