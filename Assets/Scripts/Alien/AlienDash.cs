using System.Collections;
using UnityEngine;

namespace Alien
{
    public class AlienDash : MonoBehaviour
    {
        public FloatReference DashCooldown;
        public FloatReference DashDuration;
        public IntReference CurrentLevel;
        public KeyCode DashKey = KeyCode.LeftControl;
        public FloatReference DashDistance;
        public FloatReference DashSpeed;
        public bool IsDashing = false;
        
        private bool AbilityUnlocked = false;
        private readonly int LevelWhenUnlocked = 2;
        private AlienMovement movement;
        private AlienStatsObject stats;
        
        // Start is called before the first frame update
        void Start()
        {
            movement = GetComponent<AlienMovement>();
            stats = GetComponent<StateController>().stats;
        }

        // Update is called once per frame
        void Update()
        {
            if (!AbilityUnlocked && CurrentLevel >= LevelWhenUnlocked)
            {
                AbilityUnlocked = true;
            }
            else
            {
                if (Input.GetKeyDown(DashKey))
                {
                    StartCoroutine(SetCooldown());
                    StartCoroutine(Dash());
                }
            }

            if (IsDashing)
            {
                Vector3 targetPosition = new Vector3(0, transform.position.y + DashDistance,
                    0);
                transform.Translate(targetPosition*DashSpeed* Time.deltaTime);
            }
        }

        IEnumerator Dash()
        {
            // Start dashing

            IsDashing = true;
            movement.SetFollowPlayer(false);
            
            // Done dashing
            yield return new WaitForSeconds(DashDuration);
            movement.SetFollowPlayer(true);
            IsDashing = false;

        }

        IEnumerator SetCooldown()
        {
            AbilityUnlocked = false;
            yield return new WaitForSeconds(DashCooldown);
            AbilityUnlocked = true;
        }
    }
}