using TMPro;
using UnityEngine;

namespace SpaceDodger
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private GameObject gameOverCanvas;
        [SerializeField] private GameObject scoreCanvas;
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI lastScoreText;

        private ScoreManager _scoreManager;

        private void Start()
        {
            gameOverCanvas.SetActive(false);
            _scoreManager = FindObjectOfType<ScoreManager>();
        }

        private void Update()
        {
            DisplayScore();
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
    }
}


