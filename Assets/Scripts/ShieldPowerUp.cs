namespace SpaceDodger
{
    public class ShieldPowerUp : PowerUp
    {
        private readonly string _typeText = "Shield Power-Up!";
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

