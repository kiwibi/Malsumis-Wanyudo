using UnityEngine;

namespace AI.Actions
{
    [CreateAssetMenu (menuName = "PluggableAI/Actions/FireballAction")]
    public class FireballAction : Action
    {
        public override void Act (StateController controller)
        {
            Fireball (controller); 
        }
    
        private void Fireball(StateController controller)
        {
        	var fireball = Instantiate(controller.fireball, controller.transform.position, Quaternion.identity);
            controller.stats.FireballSpawned = true;
        }
    }
}
