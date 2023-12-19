using UnityEngine;

namespace SpaceDodger
{
    public class PlayerHealth : MonoBehaviour
    {

        public void ProcessCrash()
        {
            AudioPlayer audioPlayer = FindObjectOfType<AudioPlayer>();
            audioPlayer.PlayDeathSFX();

            AsteroidSpawner asteroidSpawner = FindObjectOfType<AsteroidSpawner>();
            asteroidSpawner.enabled = false;

            PowerUpSpawner powerUpSpawner = FindObjectOfType<PowerUpSpawner>();
            powerUpSpawner.enabled = false;
            
            UIController uIController = FindObjectOfType<UIController>();
            uIController.EnableGameOverCanvas();

            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            scoreManager.IsScoreStopped = true;

            gameObject.SetActive(false);
        }
    }
}


