using UnityEngine;

namespace AI.Decisions
{
    [CreateAssetMenu(menuName = "PluggableAI/Decisions/Boss/FollowAfterDash")]
    public class BossFollowAfterDashDecision : Decision
    {
        public override bool Decide(StateController controller)
        {
            return Follow(controller);
        }

        private bool Follow(StateController controller)
        {

            return controller.CheckIfCountDownElapsed(controller.statsObject.DashDuration);
        }
    }
}
