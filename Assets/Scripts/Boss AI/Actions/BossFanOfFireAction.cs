using UnityEngine;

namespace AI.Actions
{
    [CreateAssetMenu(menuName = "PluggableAI/Actions/Boss/BossFanOfFire")]
    public class BossFanOfFireAction : Action
    {
        public override void Act(StateController controller)
        {
            BossFanOfFire(controller);
        }

        private void BossFanOfFire(StateController controller)
        {
                controller.SpawnFireBall();

        }
    }
}
