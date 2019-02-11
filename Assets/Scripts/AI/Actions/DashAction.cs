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
            Collider2D collider = controller.GetComponent<BoxCollider2D>();
            collider.enabled = true;
            Vector3 targetPosition = new Vector3(0, controller.transform.position.y + controller.stats.DashDistance,
                0);
            controller.transform.Translate(targetPosition*controller.stats.DashSpeed* Time.deltaTime);
        }
    }
}
