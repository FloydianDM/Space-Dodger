using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SpaceDodger
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private Button continueButton;

        public event Action OnGameStarted;

        public void StartGame()
        {
            SceneManager.LoadScene(1);
            
            if (OnGameStarted != null)
            {
                OnGameStarted();
            }
        }

        public void InteractContinueButton()
        {
            AdManager.Instance.ShowAd(this);
            continueButton.interactable = false;
        }

        public void ContinueGame()
        {
            player.transform.position = Vector3.zero;
            player.SetActive(true);
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;

            FindObjectOfType<AsteroidSpawner>().enabled = true;
            FindObjectOfType<PowerUpSpawner>().enabled = true;
            FindObjectOfType<UIController>().DisableGameOverCanvas();
            FindObjectOfType<ScoreManager>().IsScoreStopped = false;

        }

        public void ReturnToMenu()
        {
            SceneManager.LoadScene(0);
        }
    }
}


