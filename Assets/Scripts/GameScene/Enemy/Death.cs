using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class Death : MonoBehaviour
    {
        public List<GameObject> deathVariants;

        public Animator animator;
        public AnimationHurtInvoker animationHurtInvoker;

        void Start()
        {
            animationHurtInvoker.FinishedDie += OnFinishDie;
        }

        void Update()
        {

        }

        private void OnFinishDie()
        {
            InstantiateDeathVariant();

            animationHurtInvoker.FinishedDie -= OnFinishDie;

            Destroy(gameObject);
        }

        private void InstantiateDeathVariant()
        {
            float xInputLast = animator.GetFloat("xInput");
            float yInputLast = animator.GetFloat("yInput");

            int index = 0;

            if (xInputLast > 0.71 && (yInputLast > -0.71 && yInputLast < 0.71)) // right
            {
                index = 0;
            }
            else if ((xInputLast > -0.71 && xInputLast < 0.71) && yInputLast > 0.71) // up
            {
                index = 1;
            }

            else if (xInputLast < -0.71 && (yInputLast > -0.71 && yInputLast < 0.71)) // left
            {
                index = 2;
            }

            else if ((xInputLast > -0.71 && xInputLast < 0.71) && yInputLast < -0.71) // down
            {
                index = 3;
            }

            Instantiate(deathVariants[index], transform.position, Quaternion.identity);
        }
    }
}
