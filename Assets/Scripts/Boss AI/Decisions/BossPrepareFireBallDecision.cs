using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Decisions
{
    [CreateAssetMenu(menuName = "PluggableAI/Decisions/Boss/BossPrepareFireBall")]
    public class BossPrepareFireBallDecision : Decision
    {
        public override bool Decide(StateController controller)
        {
            return Follow(controller);
        }

        private bool Follow(StateController controller)
        {
            return controller.CheckIfCountDownElapsed(0.5f);
        }
    }
}