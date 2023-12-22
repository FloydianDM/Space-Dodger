using UnityEngine;

namespace SpaceDodger
{
    public class ComponentActivator : MonoBehaviour
    {
        [SerializeField] private GameObject shield;

        public bool IsShieldActive = false;

        private void Update()
        {
            ActivateShield();
        }

        private void ActivateShield()
        {
            if (IsShieldActive)
            {
                shield.SetActive(true);
            }
            else
            {
                shield.SetActive(false);
            }  
            
        }
    }
}
