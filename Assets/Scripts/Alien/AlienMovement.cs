using System.Collections;
using UnityEngine;

namespace Alien
{
    public class AlienMovement : MonoBehaviour
    {
        private AlienStatsObject stats;
        private AlienTarget target;
        private bool followPlayer = true;
        private AlienDash dash;

        void Start()
        {
            stats = GetComponent<StateController>().statsObject;
            dash = GetComponent<AlienDash>();
            FindTarget();
        }

        private void FindTarget()
        {
            target = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<AlienTarget>();
        }

        void Update()
        {
            if (followPlayer)
            {
                if(target != null)
                {
                    Vector2 alienTarget = target.gameObject.transform.position - transform.position;
                    transform.Translate(alienTarget * stats.AlienSpeed * Time.deltaTime);
                }

                if (Camera.main == null) return;
                Vector3 screenPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 10));

                transform.position = new Vector3(

                    Mathf.Clamp(transform.position.x, 0.1f, screenPos.x),
                    Mathf.Clamp(transform.position.y, 0.1f, screenPos.y),
                    0
                );
            }
        }

        public void SetFollowPlayer(bool value)
        {
            followPlayer = value;
        }
    }
}
