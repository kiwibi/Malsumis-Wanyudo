using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Decisions
{
    [CreateAssetMenu(menuName = "PluggableAI/Decisions/FollowAfterFireball")]
    public class FollowAfterFireBallDecision : Decision
    {
        public override bool Decide (StateController controller)
        {
            return Follow(controller);
        }

        private bool Follow(StateController controller)
        {
            return controller.stats.FireballSpawned;
        }
    }
}