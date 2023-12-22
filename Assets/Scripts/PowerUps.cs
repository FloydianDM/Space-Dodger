using UnityEngine;

namespace SpaceDodger
{
    public abstract class PowerUps : MonoBehaviour, ICollectable
    { 
        protected bool isActionExecuted;

        private void Update()
        {
            DestroyCollectible();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player"))
            {
                return;
            }
            
            PlayEffects();    
            PickedUp();
            ExecutePowerUpAction();
        }

        public void PickedUp()
        {
            UIController uiController = FindObjectOfType<UIController>();
            uiController.IsPowerUpPicked = true;
            uiController.WritePowerUpText(ReturnPowerUpText());
        }

        public void PlayEffects()
        {
            AudioPlayer audioPlayer = FindObjectOfType<AudioPlayer>();
            audioPlayer.PlayPowerUpSFX();
        }
    
        protected abstract void ExecutePowerUpAction();
        protected abstract string ReturnPowerUpText();

        public void DestroyCollectible()
        {
            if (isActionExecuted)
            {
                Destroy(gameObject);
            }
        }
    }
}

