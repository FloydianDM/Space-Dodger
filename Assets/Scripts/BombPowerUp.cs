using UnityEngine;

namespace SpaceDodger
{
    public class BombPowerUp : PowerUps
    {
        protected override void ExecutePowerUpAction()
        {
            DestroyAsteroids();
        }

        private void DestroyAsteroids()
        {
            GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");

            foreach (var asteroid in asteroids)
            {
                Destroy(asteroid);
            }

            Destroy(gameObject);
        }
    }    
}

