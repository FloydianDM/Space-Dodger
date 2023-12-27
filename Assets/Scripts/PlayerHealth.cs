using System;
using UnityEngine;

namespace SpaceDodger
{
    public class PlayerHealth : MonoBehaviour
    {   
        // for future difficulty settings configurations, add SetHealth() method.
        private int _health = 1;
        public int Health => _health;
        private AudioPlayer _audioPlayer;
        private ParticleManager _particleManager;
        public event Action OnHealthChange;
                
        private void Start()
        {
            _audioPlayer = FindObjectOfType<AudioPlayer>();
            _particleManager = FindObjectOfType<ParticleManager>();
        }

        private void Update()
        {
            HealthPowerUp healthPowerUp = FindObjectOfType<HealthPowerUp>();

            if (healthPowerUp != null && healthPowerUp.IsHealthPowerUpPicked)
            {
                AddHealth();
                healthPowerUp.IsHealthPowerUpPicked = false;
                healthPowerUp.DestroyCollectible();
            }
        }
        
        private void AddHealth()
        {
            _health ++;

            if (OnHealthChange != null)
            {
                OnHealthChange();
            }    
        }        

        public void ReduceHealth()
        {
            if (_health <= 1)
            {
                ProcessDeath();
            }
            else
            {
                _audioPlayer.PlayLoseHealthSFX();
                _particleManager.PlayCrashVFX();

                _health --;

                if (OnHealthChange != null)
                {
                    OnHealthChange();
                }
            }
        }

        private void ProcessDeath()
        {
            _audioPlayer.PlayDeathSFX();

            AsteroidSpawner asteroidSpawner = FindObjectOfType<AsteroidSpawner>();
            asteroidSpawner.enabled = false;

            PowerUpSpawner powerUpSpawner = FindObjectOfType<PowerUpSpawner>();
            powerUpSpawner.enabled = false;
            
            UIController uiController = FindObjectOfType<UIController>();
            uiController.EnableGameOverCanvas();

            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            scoreManager.IsScoreStopped = true;

            gameObject.SetActive(false);
        }
    }
}