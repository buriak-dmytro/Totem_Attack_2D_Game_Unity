using UnityEngine;

namespace BoostsManagement
{
    public class PointsPlayerBoost : Boost
    {
        private GameManagement.SessionStatus sessionStatus;

        void Start()
        {
            sessionStatus = 
                GameObject
                .FindWithTag("SessionStatus")
                .GetComponent<GameManagement.SessionStatus>();
        }

        public override void Collect()
        {
            sessionStatus.TakePoints(randomGen.Next(1, 5) * 100);
        }
    }
}
