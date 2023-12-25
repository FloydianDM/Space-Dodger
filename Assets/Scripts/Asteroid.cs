using UnityEngine;

namespace SpaceDodger
{
    public class Asteroid : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other) 
        {   
            ShieldActivator shieldActivator = FindObjectOfType<ShieldActivator>();            
            PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();

            if (other.CompareTag("Player") && !shieldActivator.IsShieldActive)
            {
                playerHealth.ProcessCrash();
            } 
            else if (other.CompareTag("Player") && shieldActivator.IsShieldActive)
            {
                DestroyAsteroid();
            }
            else
            {
                return;
            }   
        }

        private void DestroyAsteroid()
        {
            AudioPlayer audioPlayer = FindObjectOfType<AudioPlayer>();
            audioPlayer.PlayKillSFX();

            Destroy(gameObject);
        }

        private void OnBecameInvisible() 
        {
            Destroy(gameObject);    
        }
    }
}

