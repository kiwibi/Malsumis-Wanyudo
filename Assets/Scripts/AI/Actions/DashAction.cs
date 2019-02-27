using UnityEngine;

namespace AI.Actions
{
    [CreateAssetMenu (menuName = "PluggableAI/Actions/Dash")]
    public class DashAction : Action
    {
        public override void Act (StateController controller)
        {
            Dash (controller); 
        }
    
        private void Dash(StateController controller)
        {
            var Line = controller.GetComponentInChildren<LineRenderer>();
            Line.positionCount = 0;
            Collider2D collider = controller.GetComponent<BoxCollider2D>();
            collider.enabled = true;

            if (!controller.hasTarget)
            {
                controller.targetPos = new Vector3(0,
                    controller.transform.position.y + controller.statsObject.DashDistance,
                    0);
            }

            controller.transform.Translate(controller.targetPos*controller.statsObject.DashSpeed* Time.deltaTime);
        }
    }
}
