using UnityEngine;

namespace SpaceDodger
{
    public class BombPowerUp : PowerUps
    {
        private string _typeText = "Bomb Power-Up!";

        protected  override string ReturnPowerUpText()
        {
            return _typeText;
        }

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

            isActionExecuted = true;
        }
    }    
}

