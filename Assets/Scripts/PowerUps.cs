using UnityEngine;

namespace SpaceDodger
{
    public abstract class PowerUps : MonoBehaviour, ICollectable
    {
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
        }

        public void PlayEffects()
        {
            AudioPlayer audioPlayer = FindObjectOfType<AudioPlayer>();
            audioPlayer.PlayPowerUpSFX();
        }

        protected abstract void ExecutePowerUpAction();
    }
}

