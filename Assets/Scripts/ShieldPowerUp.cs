using System.Collections;
using UnityEngine;

namespace SpaceDodger
{
    public class ShieldPowerUp : PowerUps
    {
        private float _shieldActivateDuration = 8f;
        private string _typeText = "Shield Power-Up!";

        protected override string ReturnPowerUpText()
        {
           return _typeText;
        }

        protected override void ExecutePowerUpAction()
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
            StartCoroutine(ProtectShip());
        }

        private IEnumerator ProtectShip()
        {
            ComponentActivator componentActivator = FindObjectOfType<ComponentActivator>();
            componentActivator.IsShieldActive = true;

            yield return new WaitForSeconds(_shieldActivateDuration);

            componentActivator.IsShieldActive = false;
            isActionExecuted = true;
        }
    }
}

