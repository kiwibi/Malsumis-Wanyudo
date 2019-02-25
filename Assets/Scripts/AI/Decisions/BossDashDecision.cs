using UnityEngine;

namespace AI.Decisions
{
    [CreateAssetMenu(menuName = "PluggableAI/Decisions/BossDash")]
    public class BossDashDecision : Decision
    {
        public override bool Decide(StateController controller)
        {
            return Dash(controller);
        }

        private bool Dash(StateController controller)
        {
            return !controller.statsObject.DashOnCooldown;
        }
    }
}
