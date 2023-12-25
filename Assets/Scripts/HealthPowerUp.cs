namespace SpaceDodger
{
    public class HealthPowerUp : PowerUp
    {
        private readonly string _typeText = "Health Power Up!";
        public bool IsHealthPowerUpPicked = false;

        protected override void ExecutePowerUpAction()
        {
            IsHealthPowerUpPicked = true;
        }

        protected override string ReturnPowerUpText()
        {
            return _typeText;
        }

    }
}
