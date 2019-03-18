using UnityEngine;

namespace AI.Actions
{
    [CreateAssetMenu (menuName = "PluggableAI/Actions/Follow")]
    public class FollowAction : Action 
    {
        public override void Act (StateController controller)
        {
            Follow (controller); 
        }

        private void Follow(StateController controller)
        {
            controller.hasTarget = false;
            
            if (controller.chaseTarget != null)
            {
                Vector2 alienTarget = controller.chaseTarget.position - controller.transform.position;
                controller.transform.Translate(alienTarget * controller.statsObject.AlienSpeed * Time.deltaTime);
            }

            if (Camera.main == null) return;
            Vector3 screenPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 10));
            
            controller.transform.position = new Vector3(

                Mathf.Clamp(controller.transform.position.x, 0.1f, screenPos.x),
                Mathf.Clamp(controller.transform.position.y, 0.1f, screenPos.y),
                0
            );

            // Rotate towards mouse
            if (pauseMenu.isPaused == false)
            {
                Rotate(controller);
            }
            
        }

        private void Rotate(StateController controller)
        {
            Vector3 dir = controller.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Quaternion rotation =
                Quaternion.LookRotation(dir, new Vector3(0, 0, 1));
            rotation.x = 0;
            rotation.y = 0;
            controller.spriteRenderer.transform.rotation = rotation;
        }
    }
}