using UnityEngine;

namespace AI.Actions
{
    [CreateAssetMenu(menuName = "PluggableAI/Actions/Boss/BossDash")]
    public class BossDashAction : Action
    {
        public override void Act(StateController controller)
        {
            Dash(controller);
        }
        private void Dash(StateController controller)
        {
            controller.SetLightColor(controller.statsObject.dashColor);
            Vector3 direction = controller.GetDashPosition() - controller.transform.position;
            direction.z = 0;
            controller.transform.Translate(direction * controller.statsObject.DashSpeed * Time.deltaTime);
        }
    }
}
