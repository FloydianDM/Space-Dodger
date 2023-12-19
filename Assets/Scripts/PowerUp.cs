using UnityEngine;

namespace SpaceDodger
{
    public class PowerUp : MonoBehaviour
    {
        private AudioPlayer _audioPlayer;

        private void Start()
        {
            _audioPlayer = FindObjectOfType<AudioPlayer>();
        }

        private void OnTriggerEnter(Collider other) 
        {
            if (!other.CompareTag("Player"))
            {
                return;
            }

            UIController uiController = FindObjectOfType<UIController>();
            uiController.IsPowerUpPicked = true;

            _audioPlayer.PlayPowerUpSFX();

            GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");

            foreach (var asteroid in asteroids)
            {
                Destroy(asteroid);
            }

            Destroy(gameObject);
        }
    }    
}

