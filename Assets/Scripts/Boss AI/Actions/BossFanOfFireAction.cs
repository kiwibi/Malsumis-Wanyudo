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
            controller.GetComponentInChildren<Animator>().SetBool("Stand", true);
            
            if (!controller.FanOfFireOnDelay)
            {
                controller.StartCoroutine(controller.FireBalls());
            }


                if (controller.statsObject.FanOfFireFireBalls < controller.fireBallsSpawned)
                {
                    controller.statsObject.FanOfFireDone = true;
                }
        }
    }
}
