using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Actions
{
    [CreateAssetMenu(menuName = "PluggableAI/Actions/DashReturn")]
    public class DashReturnAction : Action
    {
        public override void Act(StateController controller)
        {
            Dash(controller);
        }
        private void Dash(StateController controller)
        {
            if (!controller.hasTarget)
            {
                controller.targetPos = new Vector3(0, controller.transform.position.y - controller.statsObject.DashDistance, 0);
                controller.hasTarget = true;
            }
            controller.transform.Translate(controller.targetPos * controller.statsObject.DashSpeed * Time.deltaTime);
        }
    }
}