using UnityEngine;

namespace SpaceDodger
{
    public class AudioPlayer : MonoBehaviour
    {
        [SerializeField] private AudioClip deathSFX;
        [SerializeField] private AudioClip powerUpSFX;
        [SerializeField] private AudioClip killSFX;
        [SerializeField] private AudioClip loseHealthSFX;

        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void PlayDeathSFX()
        {
            if (_audioSource.isPlaying)
            {
                _audioSource.Stop();
            }

            _audioSource.PlayOneShot(deathSFX);
        }

        public void PlayPowerUpSFX()
        {
            _audioSource.PlayOneShot(powerUpSFX);
        }

        public void PlayKillSFX()
        {
            _audioSource.PlayOneShot(killSFX);
        }

        public void PlayLoseHealthSFX()
        {
            _audioSource.PlayOneShot(loseHealthSFX);
        }
    }
    
}
