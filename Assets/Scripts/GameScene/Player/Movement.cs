using UnityEngine;

namespace Player
{
    public class Movement : MonoBehaviour
    {
        public Input input;

        public AnimationAttackInvoker animationAttackInvoker;

        public AnimationHurtInvoker animationHurtInvoker;

        private Rigidbody2D rb2D;

        public float speed;

        void Start()
        {
            rb2D = GetComponent<Rigidbody2D>();

            input.Moved += OnMove;
            input.Idled += OnIdle;

            animationAttackInvoker.StartedAttack += OnStartAttack;
            animationAttackInvoker.FinishedAttack += OnFinishAttack;

            animationHurtInvoker.StartedHurt += StartHurt;
            animationHurtInvoker.FinishedHurt += FinishHurt;

            animationHurtInvoker.StartedDie += StartDie;
        }

        private void OnMove(Vector2 move)
        {
            //Debug.Log(move.normalized);
            rb2D.AddForce(move.normalized * speed);
        }

        private void OnIdle()
        {
            rb2D.velocity = Vector2.zero;
            rb2D.angularVelocity = 0.0f;
        }

        private void OnStartAttack()
        {
            input.Moved -= OnMove;
        }

        private void OnFinishAttack()
        {
            input.Moved += OnMove;
        }

        private void StartHurt()
        {
            input.Moved -= OnMove;
        }

        private void FinishHurt()
        {
            input.Moved += OnMove;
        }

        private void StartDie()
        {
            input.Moved -= OnMove;
            input.Idled -= OnIdle;

            animationAttackInvoker.StartedAttack -= OnStartAttack;
            animationAttackInvoker.FinishedAttack -= OnFinishAttack;

            animationHurtInvoker.StartedHurt -= StartHurt;
            animationHurtInvoker.FinishedHurt -= FinishHurt;

            animationHurtInvoker.StartedDie -= StartDie;
        }
    }
}
