using UnityEngine;

namespace AI.Actions
{
    [CreateAssetMenu(menuName = "PluggableAI/Actions/Boss/BossFireball")]
    public class BossFireballAction : Action
    {
        public override void Act(StateController controller)
        {
            Fireball(controller);
        }

        private void Fireball(StateController controller)
        {
            int beginningAngle = controller.statsObject.fireballAngle; //-60;
            int fireBallSpread = controller.statsObject.fireballSpread; // 30
            for (int fireBallNumber = 0; fireBallNumber < controller.statsObject.fireBalls; fireBallNumber++) // 5
            {
                var fireball = Instantiate(controller.fireball, controller.transform.position, Quaternion.identity);
                fireball.transform.rotation = Quaternion.AngleAxis(beginningAngle + (fireBallSpread * fireBallNumber), Vector3.back);
            }

            controller.statsObject.FireballSpawned = true;
            /*
            {
                var fireball = Instantiate(controller.fireball, controller.transform.position, Quaternion.identity);
                fireball.GetComponent<MoveFireBall>().FollowPlayer = true;
                controller.statsObject.FireballSpawned = true;
            }
            */
        }
    }
}
