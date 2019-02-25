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
            return controller.statsObject.AlienLevel >= 2 && !controller.statsObject.DashOnCooldown && Input.GetKeyDown(controller.statsObject.DashKey) ? true : false;
        }
    }
}