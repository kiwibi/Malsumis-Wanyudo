using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Decisions
{
    [CreateAssetMenu(menuName = "PluggableAI/Decisions/PrepareDash")]
    public class PrepareDashDecision : Decision
    {
        public override bool Decide(StateController controller)
        {
            return Dash(controller);
        }

        private bool Dash(StateController controller)
        {
            return controller.statsObject.AlienLevel >= 2 && !controller.statsObject.DashOnCooldown &&
                   Input.GetKeyDown(controller.statsObject.DashKey);
        }
    }
}