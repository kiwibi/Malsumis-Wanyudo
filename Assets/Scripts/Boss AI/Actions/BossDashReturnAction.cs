using UnityEngine;

namespace AI.Actions
{
    [CreateAssetMenu(menuName = "PluggableAI/Actions/BossDashReturn")]
    public class BossDashReturnAction : Action
    {
        public override void Act(StateController controller)
        {
            Dash(controller);
        }
        private void Dash(StateController controller)
        {
            Vector3 direction = controller.dashStartingPosition - controller.transform.position;
            controller.transform.Translate(direction * controller.statsObject.DashSpeed * Time.deltaTime);
        }
    }
}
