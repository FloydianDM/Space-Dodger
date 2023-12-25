using System.Collections;
using UnityEngine;

namespace SpaceDodger
{
    public class ShieldActivator : MonoBehaviour
    {
        [SerializeField] private GameObject shield;

        private float _shieldActivationDuration = 8f;
        public bool IsShieldActive = false;

        private void Start()
        {
            shield.SetActive(false);
        }

        private void Update()
        {
            ShieldPowerUp shieldPowerUp = FindObjectOfType<ShieldPowerUp>();

            if (shieldPowerUp != null && shieldPowerUp.IsShieldPowerUpPicked)
            {
                StartCoroutine(ActivateShield());
                shieldPowerUp.DestroyCollectible();
            }
        }

        private IEnumerator ActivateShield()
        {
            shield.SetActive(true);
            IsShieldActive = true;

            yield return new WaitForSeconds(_shieldActivationDuration);

            shield.SetActive(false);
            IsShieldActive = false;            
        }
    }
}
