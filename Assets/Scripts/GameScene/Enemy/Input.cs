using System;
using UnityEngine;

namespace Enemy
{
    public class Input : MonoBehaviour
    {
        public event Action<Vector2> Moved;
        public event Action Idled;
        public event Action Fired;

        public Brain brain;

        public Health health;

        private Vector2 moveValue = Vector2.zero;

        private bool isMoving = false;

        void Start()
        {
            brain.Fired += OnFire;
            brain.Moved += OnMove;

            health.Died += OnDie;
        }

        void FixedUpdate()
        {
            if (isMoving)
                Moved?.Invoke(moveValue);
            else
                Idled?.Invoke();
        }

        private void OnMove(Vector2 move)
        {
            moveValue = move;
            isMoving = moveValue.magnitude > 0;
        }

        private void OnFire()
        {
            Fired?.Invoke();
        }

        private void OnDie()
        {
            brain.Fired -= OnFire;
            brain.Moved -= OnMove;

            health.Died -= OnDie;
        }
    }
}
