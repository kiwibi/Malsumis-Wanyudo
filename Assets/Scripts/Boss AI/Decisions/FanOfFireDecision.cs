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
            if (controller.AlienHealth.Value <= controller.AlienMaxHealth.Value / 2)
            {
                return !controller.statsObject.FanOfFireOnCooldown;
            }

            return false;
        }
    }
}