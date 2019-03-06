using System.Net.WebSockets;
using UnityEngine;

namespace AI.Actions
{
    [CreateAssetMenu (menuName = "PluggableAI/Actions/Dash")]
    public class DashAction : Action
    {
        public override void Act (StateController controller)
        {
            Dash (controller); 
        }
    
        private void Dash(StateController controller)
        {
            var Line = controller.GetComponentInChildren<LineRenderer>();
            var animator = controller.GetComponentInChildren<Animator>();
            animator.SetBool("IsDashing", true);
            Line.positionCount = 0;
            Collider2D collider = controller.GetComponent<BoxCollider2D>();
            collider.enabled = true;

            var enemies = GameObject.FindGameObjectsWithTag("Enemy");


            if (!controller.hasTarget)
            {
                float closestEnemyDist = 100;
                foreach (var enemy in enemies)
                {
                    var distance = Vector3.Distance(enemy.transform.position, controller.transform.position);
                    if (distance < closestEnemyDist)
                    {
                        closestEnemyDist = distance;
                        var direction = enemy.transform.position - controller.transform.position;
                        controller.targetPos = direction * controller.statsObject.DashDistance;
                        Vector3 up = new Vector3(0, 0, -1);
                        var rotation = Quaternion.LookRotation(direction, up);
                        rotation.x = 0;
                        rotation.y = 0;
                        controller.GetComponentInChildren<SpriteRenderer>().transform.rotation = rotation;
                    }
                }

                controller.hasTarget = true;
            }
            
            /*
            if (!controller.hasTarget)
            {
                controller.targetPos = new Vector3(0,
                    controller.transform.position.y + controller.statsObject.DashDistance,
                    0);
            }
            */

            controller.transform.Translate(controller.targetPos*controller.statsObject.DashSpeed* Time.deltaTime);
        }
    }
}
