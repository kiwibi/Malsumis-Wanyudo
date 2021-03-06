﻿using UnityEngine;

namespace AI.Actions
{
    [CreateAssetMenu (menuName = "PluggableAI/Actions/FireballAction")]
    public class FireBallAction : Action
    {
        public override void Act (StateController controller)
        {
            Fireball (controller); 
        }
    
        private void Fireball(StateController controller)
        {
            var Line = controller.GetComponentInChildren<LineRenderer>();
            Line.positionCount = 0;
            
            var smallFireball = controller.GetComponentInChildren<SpawnFireball>();
            smallFireball.spawning = false;
            
        	var fireball = Instantiate(controller.fireball, controller.transform.position, Quaternion.identity);
            controller.statsObject.FireballSpawned = true;
        }
    }
}
