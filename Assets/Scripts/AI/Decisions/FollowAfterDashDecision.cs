using UnityEngine;

namespace AI.Decisions
{
    [CreateAssetMenu (menuName = "PluggableAI/Decisions/FollowAfterDash")]
    public class FollowAfterDashDecision : Decision 
    {
        public override bool Decide (StateController controller)
        {
            return Follow(controller);
        }

        private bool Follow(StateController controller)
        {
            return controller.CheckIfCountDownElapsed(controller.statsObject.DashDuration);
        }
    }
}