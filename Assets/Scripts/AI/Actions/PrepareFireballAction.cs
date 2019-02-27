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
            var Line = controller.GetComponentInChildren<LineRenderer>();
            Line.positionCount = 2;
            Line.material = controller.FireballMaterial;
            Line.SetPosition(0, controller.transform.position);

            Vector2 direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - controller.transform.position).normalized;
            Line.SetPosition(1, new Vector2(controller.transform.position.x, controller.transform.position.y) + direction * 1000);
            
            var smallFireball = controller.GetComponentInChildren<SpawnFireball>();
            smallFireball.spawning = true;
        }
    }
}