using System;
using UnityEngine;

namespace SpaceDodger
{
    public class PlayerHealth : MonoBehaviour
    {
        private int _initialHealth = 1;
        private int _health = 1;
        public int Health => _health;

        private GameManager _gameManager;
        private AudioPlayer _audioPlayer;
        public event Action OnHealthChange;
                
        private void Start()
        {
            _gameManager = FindObjectOfType<GameManager>();
            _audioPlayer = FindObjectOfType<AudioPlayer>();

            _gameManager.OnGameStarted += ResetHealth;   
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

        private void ResetHealth()
        {
            _health = _initialHealth;

            if (OnHealthChange != null)
            {
                OnHealthChange();
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
            
            UIController uIController = FindObjectOfType<UIController>();
            uIController.EnableGameOverCanvas();

            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            scoreManager.IsScoreStopped = true;

            ResetHealth();

            gameObject.SetActive(false);
        }
    }
}


