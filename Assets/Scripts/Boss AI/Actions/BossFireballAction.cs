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
            var fireball = Instantiate(controller.fireball, controller.transform.position, Quaternion.identity);
            fireball.GetComponent<MoveFireBall>().FollowPlayer = true;
            controller.statsObject.FireballSpawned = true;
        }
    }
}
