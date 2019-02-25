using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Actions
{
    [CreateAssetMenu(menuName = "PluggableAI/Actions/PrepareDash")]
    public class PrepareDashAction : Action
    {
        public override void Act(StateController controller)
        {
            Dash(controller);
        }

        private void Dash(StateController controller)
        {
            // TODO show dash targeting
        }
    }
}
