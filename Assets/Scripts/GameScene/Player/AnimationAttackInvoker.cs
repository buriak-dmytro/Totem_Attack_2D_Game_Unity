using System;
using UnityEngine;

namespace Player
{
    public class AnimationAttackInvoker : MonoBehaviour
    {
        public event Action StartedAttack;
        public event Action FinishedAttack;

        private bool isAttackInvoked = false;

        private void StartAttack()
        {
            if (!isAttackInvoked)
            {
                StartedAttack?.Invoke();
                isAttackInvoked = true;
            }
        }

        private void FinishAttack()
        {
            if (isAttackInvoked)
            {
                FinishedAttack?.Invoke();
                isAttackInvoked = false;
            }
        }
    }
}
