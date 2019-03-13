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
            int randomInt = Random.Range(0, 2);
            int beginningAngle = 0;
            if (randomInt == 1)
            {
                beginningAngle = controller.statsObject.fireballAngle;
            }
            else
            {
                beginningAngle = controller.statsObject.fireballAngle2;
            }
            
            
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
