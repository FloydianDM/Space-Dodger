using System;
using UnityEngine;

namespace SpaceDodger
{
    public class PlayerHealth : MonoBehaviour
    {
        public int Health { get; private set; }
        private int _initialHealth = 1;

        private GameManager _gameManager;
        public event Action OnHealthChange;
                
        private void Start()
        {
            Health = _initialHealth;

            _gameManager = FindObjectOfType<GameManager>();
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
            Health = _initialHealth;

            if (OnHealthChange != null)
            {
                OnHealthChange();
            }
        }

        private void AddHealth()
        {
            Health ++;

            if (OnHealthChange != null)
            {
                OnHealthChange();
            }    
        }        

        public void ReduceHealth()
        {
            if (Health <= 1)
            {
                ProcessDeath();
            }
            else
            {
                Health --;

                if (OnHealthChange != null)
                {
                    OnHealthChange();
                }
            }
        }

        private void ProcessDeath()
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


