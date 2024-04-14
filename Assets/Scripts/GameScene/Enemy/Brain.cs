using System;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class Brain : MonoBehaviour
    {
        public event Action<Vector2> Moved;
        public event Action Fired;

        public NavMeshAgent agent;

        public FollowObject followObject;
        public HitObject hitObject;

        public AnimationAttackInvoker animationAttackInvoker;

        public Health health;

        private bool isMoving = true;
        private bool isAttacking = false;
        private bool isAttackFinished = true;

        public GameObject totem;
        private GameObject currentFollowedObject;

        void Start()
        {
            agent.updateRotation = false;
            agent.updateUpAxis = false;

            followObject.Followed += OnFollow;
            followObject.Unfollowed += OnUnfollow;

            hitObject.InRangeTarget += OnInRangeTarget;
            hitObject.OutRangeTarget += OnOutRangeTarget;

            animationAttackInvoker.StartedAttack += OnStartAttack;
            animationAttackInvoker.FinishedAttack += OnFinishAttack;

            health.Died += OnDie;

            currentFollowedObject = totem;
        }

        void FixedUpdate()
        {
            if (isAttackFinished)
            {
                if (isMoving)
                {
                    agent.SetDestination(currentFollowedObject.transform.position);

                    Vector2 move = agent.velocity.normalized;

                    Moved?.Invoke(move);
                }
                else
                {
                    Moved?.Invoke(
                        Vector2.zero
                    );
                }
            }

            if (isAttacking)
            {
                Fired?.Invoke();
            }
        }

        private void OnFollow(GameObject gameObject)
        {
            isMoving = true;
            isAttacking = false;

            currentFollowedObject = gameObject;
        }

        private void OnUnfollow()
        {
            currentFollowedObject = totem;
        }

        private void OnInRangeTarget()
        {
            isMoving = false;
            isAttacking = true;
        }

        private void OnOutRangeTarget()
        {
            isMoving = true;
            isAttacking = false;
        }

        private void OnStartAttack()
        {
            isAttackFinished = false;
        }

        private void OnFinishAttack()
        {
            isAttackFinished = true;
        }

        private void OnDie()
        {
            followObject.Followed -= OnFollow;
            followObject.Unfollowed -= OnUnfollow;

            hitObject.InRangeTarget -= OnInRangeTarget;
            hitObject.OutRangeTarget -= OnOutRangeTarget;

            animationAttackInvoker.StartedAttack -= OnStartAttack;
            animationAttackInvoker.FinishedAttack -= OnFinishAttack;

            health.Died -= OnDie;
        }
    }
}
