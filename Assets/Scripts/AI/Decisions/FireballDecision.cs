using UnityEngine;

namespace AI.Decisions
{
    [CreateAssetMenu (menuName = "PluggableAI/Decisions/Fireball")]
    public class FireballDecision : Decision 
    {
        public override bool Decide (StateController controller)
        {
            return Fireball(controller);
        }

        private bool Fireball(StateController controller)
        {
            return controller.statsObject.AlienLevel >= 3 && !controller.statsObject.FireballOnCooldown && Input.GetKeyDown(controller.statsObject.FireballKey) ? true : false;
        }
    }
}