using System.Collections;
using TMPro;
using UnityEngine;

namespace SpaceDodger
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private GameObject gameOverCanvas;
        [SerializeField] private GameObject scoreCanvas;
        [SerializeField] private GameObject healthCanvas;
        [SerializeField] private GameObject powerUpCanvas;
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI healthText;
        [SerializeField] private TextMeshProUGUI lastScoreText;
        [SerializeField] private TextMeshProUGUI powerUpText;

        private string _powerUpTextString = "";
        private ScoreManager _scoreManager;
        private PlayerHealth _playerHealth;
        public bool IsPowerUpPicked = false;

        private void Start()
        {
            gameOverCanvas.SetActive(false);
            powerUpCanvas.SetActive(false);

            _scoreManager = FindObjectOfType<ScoreManager>();
            _playerHealth = FindObjectOfType<PlayerHealth>();

            DisplayHealth();

            _scoreManager.OnScoreChange += DisplayScore;
            _playerHealth.OnHealthChange += DisplayHealth;
        }

        private void Update()
        {
            if (IsPowerUpPicked)
            {
                StartCoroutine(TogglePowerUpCanvas());
            }
        }

        private void DisplayScore()
        {
            scoreText.text = $"Score: {_scoreManager.Score}";
        }
        
        private void DisplayHealth()
        {
            healthText.text = $"Health: {_playerHealth.Health}";
        }

        public void EnableGameOverCanvas()
        {
            gameOverCanvas.SetActive(true);
            scoreCanvas.SetActive(false);
            healthCanvas.SetActive(false);
            
            lastScoreText.text = $"Score: {_scoreManager.Score}";
        }

        public void DisableGameOverCanvas()
        {
            gameObject.SetActive(false);
            scoreCanvas.SetActive(true);
            healthCanvas.SetActive(true);
        }

        public void WritePowerUpText(string typeText)
        {
            _powerUpTextString = typeText;   
        }

        private IEnumerator TogglePowerUpCanvas()
        {
            IsPowerUpPicked = false;

            powerUpCanvas.SetActive(true);

            powerUpText.text = _powerUpTextString;

            yield return new WaitForSeconds(1);

            powerUpCanvas.SetActive(false);
        }

    }
}


