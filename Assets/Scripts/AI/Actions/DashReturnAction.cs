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
            var animator = controller.GetComponentInChildren<Animator>();
            if (animator == null)
                Debug.Log("null animator");
            animator.SetBool("IsDashing", false);
            if (!controller.hasTarget)
            {
                controller.targetPos = new Vector3(0, controller.transform.position.y - controller.statsObject.DashDistance, 0);
                controller.hasTarget = true;
            }
            controller.transform.Translate(controller.targetPos * controller.statsObject.DashSpeed * Time.deltaTime);
        }
    }
}