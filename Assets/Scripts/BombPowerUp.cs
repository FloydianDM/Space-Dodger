using UnityEngine;

namespace SpaceDodger
{
    public class BombPowerUp : PowerUp
    {
        private readonly string _typeText = "Bomb Power-Up!";

        protected  override string ReturnPowerUpText()
        {
            return _typeText;
        }

        protected override void ExecutePowerUpAction()
        {
            DestroyAsteroids();
            DestroyCollectible();
        }

        private void DestroyAsteroids()
        {
            GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");

            foreach (var asteroid in asteroids)
            {
                Destroy(asteroid);
            }
        }
    }    
}

