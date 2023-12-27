using UnityEngine;

namespace SpaceDodger
{
    public class ParticleManager : MonoBehaviour
    {
        [SerializeField] private GameObject killVFXGameObject;
        [SerializeField] private GameObject crashVFXGameObject;
        [SerializeField] private GameObject powerUpVFXGameObject;

        private ParticleSystem _killVFX;
        private ParticleSystem _crashVFX;
        private ParticleSystem _powerUpVFX;
        
        private void Start()
        {
            SetParticles();
        }

        private void SetParticles()
        {
            _killVFX = killVFXGameObject.GetComponent<ParticleSystem>();
            _crashVFX = crashVFXGameObject.GetComponent<ParticleSystem>();
            _powerUpVFX = powerUpVFXGameObject.GetComponent<ParticleSystem>();
        }

        public void PlayKillVFX()
        {
           _killVFX.Play();
        }

        public void PlayCrashVFX()
        {
            _crashVFX.Play();
        }

        public void PlayPowerUpVFX()
        {
            _powerUpVFX.Play();
        }
    }    
}

