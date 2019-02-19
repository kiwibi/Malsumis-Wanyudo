using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Actions {

    [CreateAssetMenu(menuName = "PluggableAI/Actions/BossBeforeDash")]
    public class BossBeforeDashAction : Action
    {
        public override void Act(StateController controller)
        {
            Dash(controller);
        }
        private void Dash(StateController controller)
        {
            controller.SetLightColor(Color.red);
        }
    }
}