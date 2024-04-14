using System;
using UnityEngine;

namespace Totem
{
    public class AnimationHurtInvoker : MonoBehaviour
    {
        public event Action StartedHurt;
        public event Action FinishedHurt;

        public event Action StartedDie;
        public event Action FinishedDie;

        private bool isHurtInvoked = false;
        private bool isDieInvoked = false;

        private void StartHurt()
        {
            if (!isHurtInvoked)
            {
                StartedHurt?.Invoke();
                isHurtInvoked = true;
            }
        }

        private void FinishHurt()
        {
            if (isHurtInvoked)
            {
                FinishedHurt?.Invoke();
                isHurtInvoked = false;
            }
        }

        private void StartDie()
        {
            if (!isDieInvoked)
            {
                StartedDie?.Invoke();
                isDieInvoked = true;
            }
        }

        private void FinishDie()
        {
            if (isDieInvoked)
            {
                FinishedDie?.Invoke();
                isDieInvoked = false;
            }
        }
    }
}
