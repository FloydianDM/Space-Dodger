using UnityEngine;

namespace SpaceDodger
{
    public class PowerUp : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other) 
        {
            if (!other.CompareTag("Player"))
            {
                return;
            }

            GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");

            foreach (var asteroid in asteroids)
            {
                Destroy(asteroid);
            }

            Destroy(gameObject);
        }
    }    
}

