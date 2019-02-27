using UnityEngine;

namespace AI.Decisions
{
    [CreateAssetMenu (menuName = "PluggableAI/Decisions/Dash")]
    public class DashDecision : Decision 
    {
        public override bool Decide (StateController controller)
        {
            return Dash(controller);
        }

        private bool Dash(StateController controller)
        {
            return Input.GetMouseButtonDown(1) || Input.GetButtonDown("q");
        }
    }
}