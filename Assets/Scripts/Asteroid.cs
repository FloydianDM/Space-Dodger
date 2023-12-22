using UnityEngine;

namespace SpaceDodger
{
    public class Asteroid : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other) 
        {   
            ComponentActivator componentActivator = FindObjectOfType<ComponentActivator>();            
            PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();

            if (other.CompareTag("Player") && !componentActivator.IsShieldActive)
            {
                playerHealth.ProcessCrash();
            } 
            else if (other.CompareTag("Player") && componentActivator.IsShieldActive)
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

