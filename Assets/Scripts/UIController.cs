using System.Collections;
using TMPro;
using UnityEngine;

namespace SpaceDodger
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private UnityEngine.GameObject gameOverCanvas;
        [SerializeField] private UnityEngine.GameObject scoreCanvas;
        [SerializeField] private UnityEngine.GameObject powerUpCanvas;
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI lastScoreText;
        [SerializeField] private TextMeshProUGUI powerUpText;

        private ScoreManager _scoreManager;
        public bool IsPowerUpPicked = false;

        private void Start()
        {
            gameOverCanvas.SetActive(false);
            powerUpCanvas.SetActive(false);
            _scoreManager = FindObjectOfType<ScoreManager>();
        }

        private void Update()
        {
            DisplayScore();

            if (IsPowerUpPicked)
            {
                StartCoroutine(TogglePowerUpCanvas());
            }
        }

        private void DisplayScore()
        {
            scoreText.text = $"Score: {_scoreManager.Score}";
        }

        public void EnableGameOverCanvas()
        {
            gameOverCanvas.SetActive(true);
            scoreCanvas.SetActive(false);
            
            lastScoreText.text = $"Score: {_scoreManager.Score}";
        }

        public void DisableGameOverCanvas()
        {
            gameObject.SetActive(false);
            scoreCanvas.SetActive(true);
        }

        private IEnumerator TogglePowerUpCanvas()
        {
            IsPowerUpPicked = false;

            powerUpCanvas.SetActive(true);
            powerUpText.text = "Asteroid Destroyer Picked Up!";

            yield return new WaitForSeconds(1);

            powerUpCanvas.SetActive(false);
        }
    }
}


