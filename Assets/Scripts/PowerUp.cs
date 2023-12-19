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

            UIController uiController = FindObjectOfType<UIController>();
            uiController.IsPowerUpPicked = true;

            GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");

            foreach (var asteroid in asteroids)
            {
                Destroy(asteroid);
            }

            Destroy(gameObject);
        }
    }    
}

