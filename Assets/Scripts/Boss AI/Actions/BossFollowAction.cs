using UnityEngine;

namespace AI.Actions
{
    [CreateAssetMenu(menuName = "PluggableAI/Actions/Boss/BossFollow")]
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

                controller.transform.Translate(alienTarget * controller.statsObject.AlienSpeed * Time.deltaTime);

                if (controller.transform.position.y <= controller.statsObject.returningLocation)
                {
                    controller.transform.Translate(Vector2.up * controller.statsObject.AlienSpeed * Time.deltaTime);
                }
            }

            if (Camera.main == null)
            {
                return;
            }

            Vector3 screenPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 10));

            controller.transform.position = new Vector3(

                Mathf.Clamp(controller.transform.position.x, 0.1f, screenPos.x),
                Mathf.Clamp(controller.transform.position.y, 0.1f, screenPos.y),
                0
            );

            // Rotate towards player
            Quaternion rotation =
                Quaternion.LookRotation(GameObject.FindGameObjectWithTag("Player").transform.position - controller.transform.position, new Vector3(0, 0, -1));
            rotation.x = 0;
            rotation.y = 0;
            controller.spriteRenderer.transform.rotation = rotation;
        }
    }
}
