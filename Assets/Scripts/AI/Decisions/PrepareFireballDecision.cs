using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Decisions
{
    [CreateAssetMenu(menuName = "PluggableAI/Decisions/PrepareFireball")]
    public class PrepareFireballDecision : Decision
    {
        public override bool Decide(StateController controller)
        {
            return Fireball(controller);
        }

        private bool Fireball(StateController controller)
        {
            return controller.statsObject.AlienLevel >= 3 && !controller.statsObject.FireballOnCooldown &&
                   Input.GetKeyDown(controller.statsObject.FireballKey);
        }
    }
}
