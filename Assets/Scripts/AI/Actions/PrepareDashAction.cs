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
            var Line = controller.GetComponentInChildren<LineRenderer>();
            Line.positionCount = 2;
            Line.material = controller.DashMaterial;
            Line.SetPosition(0, controller.transform.position);
            Line.SetPosition(1, controller.transform.position + controller.transform.up*10);
        }
    }
}
