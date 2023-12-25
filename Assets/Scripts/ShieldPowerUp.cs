using System;
using System.Collections;
using UnityEngine;

namespace SpaceDodger
{
    public class ShieldPowerUp : PowerUps
    {
        private string _typeText = "Shield Power-Up!";
        public bool IsShieldPowerUpPicked = false;

        protected override string ReturnPowerUpText()
        {
           return _typeText;
        }

        protected override void ExecutePowerUpAction()
        {
            IsShieldPowerUpPicked = true;
        }
    }
}

