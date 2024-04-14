using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class Input : MonoBehaviour
    {
        public event Action<Vector2> Moved;
        public event Action Idled;
        public event Action Fired;

        private Vector2 moveValue = Vector2.zero;

        private bool isMoving = false;

        void FixedUpdate()
        {
            if (isMoving)
                Moved?.Invoke(moveValue);
            else
                Idled?.Invoke();
        }

        void OnMove(InputValue inputValue)
        {
            moveValue = inputValue.Get<Vector2>();
            isMoving = moveValue.magnitude > 0;
        }

        void OnFire(InputValue inputValue)
        {
            Fired?.Invoke();
        }
    }
}
