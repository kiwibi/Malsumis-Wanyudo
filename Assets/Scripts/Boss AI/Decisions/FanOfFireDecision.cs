using UnityEngine;

namespace AI.Decisions
{
    [CreateAssetMenu(menuName = "PluggableAI/Decisions/Boss/FanOfFire")]
    public class FanOfFireDecision : Decision
    {
        public override bool Decide(StateController controller)
        {
            return FanOfFire(controller);
        }

        private bool FanOfFire(StateController controller)
        {
            return !controller.statsObject.FanOfFireOnCooldown;
        }
    }
}