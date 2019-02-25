using UnityEngine;

namespace AI.Decisions
{
    [CreateAssetMenu(menuName = "PluggableAI/Decisions/BossFireball")]
    public class BossFireballDecision : Decision
    {
        public override bool Decide(StateController controller)
        {
            return Fireball(controller);
        }

        private bool Fireball(StateController controller)
        {
            return !controller.statsObject.FireballOnCooldown;
        }
    }
}
