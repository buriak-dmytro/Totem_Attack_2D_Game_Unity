using UnityEngine;

namespace Enemy
{
    public class Animations : MonoBehaviour
    {
        public Input input;

        private Animator animator;

        public Health health;

        void Start()
        {
            input.Moved += OnMove;
            input.Idled += OnIdle;
            input.Fired += OnFire;

            health.Hurt += OnHurt;
            health.Died += OnDie;

            animator = GetComponent<Animator>();
        }

        private void OnMove(Vector2 move)
        {
            animator.SetFloat("xInput", move.x);
            animator.SetFloat("yInput", move.y);
            animator.SetBool("isMoving", true);

            animator.ResetTrigger("attack");
        }

        private void OnIdle()
        {
            animator.SetBool("isMoving", false);
        }

        private void OnFire()
        {
            animator.SetTrigger("attack");
        }

        private void OnHurt()
        {
            animator.SetTrigger("hurt");
        }

        private void OnDie()
        {
            animator.SetBool("isDead", true);

            input.Moved -= OnMove;
            input.Idled -= OnIdle;
            input.Fired -= OnFire;

            health.Hurt -= OnHurt;
            health.Died -= OnDie;
        }
    }
}
