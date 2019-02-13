using UnityEngine;

namespace AI.Decisions
{
    [CreateAssetMenu (menuName = "PluggableAI/Decisions/Dash")]
    public class DashDecision : Decision 
    {
        public override bool Decide (StateController controller)
        {
            return Dash(controller);
        }

        private bool Dash(StateController controller)
        {
            return controller.stats.AlienLevel >= 2 && !controller.stats.DashOnCooldown && Input.GetKeyDown(controller.stats.DashKey) ? true : false;
        }
    }
}