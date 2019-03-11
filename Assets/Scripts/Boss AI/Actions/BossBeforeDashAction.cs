using UnityEngine;

namespace AI.Actions
{

    [CreateAssetMenu(menuName = "PluggableAI/Actions/Boss/BossBeforeDash")]
    public class BossBeforeDashAction : Action
    {
        public override void Act(StateController controller)
        {
            Dash(controller);
        }
        private void Dash(StateController controller)
        {
            controller.SetLightColor(controller.statsObject.dashColor);
            controller.SetDashTarget(GameObject.FindGameObjectWithTag("Player").transform.position);

            // Rotate towards player
            Quaternion rotation =
                Quaternion.LookRotation(GameObject.FindGameObjectWithTag("Player").transform.position - controller.transform.position, new Vector3(0, 0, -1));
            rotation.x = 0;
            rotation.y = 0;
            controller.spriteRenderer.transform.rotation = rotation;
        }
    }
}
