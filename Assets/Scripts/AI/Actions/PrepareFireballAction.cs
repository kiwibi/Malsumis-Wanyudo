using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Actions
{
    [CreateAssetMenu(menuName = "PluggableAI/Actions/PrepareFireball")]
    public class PrepareFireballAction : Action
    {
        public override void Act(StateController controller)
        {
            Fireball(controller);
        }

        private void Fireball(StateController controller)
        {
            var smallFireball = controller.GetComponentInChildren<SpawnFireball>();
            smallFireball.spawning = true;
        }
    }
}