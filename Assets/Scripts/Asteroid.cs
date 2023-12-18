using UnityEngine;

namespace SpaceDodger
{
    public class Asteroid : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other) 
        {
            PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();

            if (other.CompareTag("Player"))
            {
                playerHealth.ProcessCrash();
            } 
            else
            {
                return;
            }   
        }

        private void OnBecameInvisible() 
        {
            Destroy(gameObject);    
        }
    }
}

