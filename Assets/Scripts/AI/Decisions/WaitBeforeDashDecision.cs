using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Actions
{
    [CreateAssetMenu(menuName = "PluggableAI/Decisions/BossWaitBeforeDash")]
    public class WaitBeforeDashDecision : Decision
    {
        public override bool Decide(StateController controller)
        {
            return Follow(controller);
        }

        private bool Follow(StateController controller)
        {
            return controller.CheckIfCountDownElapsed(controller.stats.waitBeforeDash);
        }
    }
}