using UnityEngine;

namespace SpaceDodger
{
    public abstract class PowerUp : MonoBehaviour, ICollectable
    { 
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player"))
            {
                return;
            }

            PlayEffects();    
            SendPickedUpText();
            ExecutePowerUpAction();
        }

        public void SendPickedUpText()
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

        private void OnBecameInvisible() 
        {
            DestroyCollectible();    
        }

        public void DestroyCollectible()
        {
            Destroy(gameObject);
        }
    }
}

