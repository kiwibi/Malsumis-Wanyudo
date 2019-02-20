using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Actions
{
    [CreateAssetMenu(menuName = "PluggableAI/Actions/BossFollow")]
    public class BossFollowAction : Action
    {
        public override void Act(StateController controller)
        {
            Follow(controller);
        }

        private void Follow(StateController controller)
        {
            controller.SetLightColor(Color.white);

            if (controller.chaseTarget != null)
            {
                Vector3 newAlienTarget = new Vector3(controller.chaseTarget.transform.position.x, 0, 0);
                Vector3 alienTarget = newAlienTarget - controller.transform.position;
                alienTarget.y = 0;
                alienTarget.z = 0;

                controller.transform.Translate(alienTarget * controller.stats.AlienSpeed * Time.deltaTime);

                if(controller.transform.position.y <= controller.stats.returningLocation)
                {
                    controller.transform.Translate(Vector2.up * controller.stats.AlienSpeed * Time.deltaTime);
                }
            }

            if (Camera.main == null) return;
            Vector3 screenPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 10));

            controller.transform.position = new Vector3(

                Mathf.Clamp(controller.transform.position.x, 0.1f, screenPos.x),
                Mathf.Clamp(controller.transform.position.y, 0.1f, screenPos.y),
                0
            );
        }
    }
}
