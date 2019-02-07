using UnityEngine;

namespace AI.Decisions
{
    [CreateAssetMenu (menuName = "PluggableAI/Decisions/Follow")]
    public class FollowDecision : Decision 
    {
        public override bool Decide (StateController controller)
        {
            return Follow(controller);
        }

        private bool Follow(StateController controller)
        {
            return controller.CheckIfCountDownElapsed(controller.stats.DashDuration);
        }
    }
}