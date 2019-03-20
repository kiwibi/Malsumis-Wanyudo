using UnityEngine;

namespace AI.Decisions
{
    [CreateAssetMenu(menuName = "PluggableAI/Decisions/Boss/BossFollowAfterFanOfFire")]
    public class BossFollowAfterFanOfFire : Decision
    {
        public override bool Decide(StateController controller)
        {
            return Follow(controller);
        }

        private bool Follow(StateController controller)
        {

            return controller.statsObject.FanOfFireDone;
        }
    }
}
