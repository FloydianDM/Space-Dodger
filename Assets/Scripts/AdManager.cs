using UnityEngine;
using UnityEngine.Advertisements;

namespace SpaceDodger
{
    public class AdManager : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
    {
        [SerializeField] private string androidGameId;
        [SerializeField] private string iOSGameId;
        [SerializeField] private bool isTestMode = true;
        [SerializeField] private string androidAdUnitId;
        [SerializeField] private string iOSAdUnitId;

        public static AdManager Instance;

        private string _gameId;
        private string _adUnitId;
        private GameManager _gameManager;

        private void Awake()
        {
            ManageSingleton();
        }

        private void ManageSingleton()
        {
            if (Instance != null && Instance != this)
            {
                gameObject.SetActive(false);
                Destroy(gameObject);
            }
            else
            {
                InitializeAds();
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        private void InitializeAds()
        {
    #if UNITY_IOS
            _gameId = iOSGameId;
            _adUnitId = iOSAdUnitId;
    #elif UNITY_ANDROID
            _gameId = androidGameId;
            _adUnitId = androidAdUnitId;
    #elif UNITY_EDITOR
            _gameId = androidGameId;
            _adUnitId = androidAdUnitId;
    #endif

            if (!Advertisement.isInitialized)
            {
                Advertisement.Initialize(_gameId, isTestMode, this);
            }
        }

        public void OnInitializationComplete()
        {
            Debug.Log("Ad Initialization Complete");
        }

        public void OnInitializationFailed(UnityAdsInitializationError error, string message)
        {
            Debug.Log("Ad Initialization Failed");
        }

        public void OnUnityAdsAdLoaded(string placementId)
        {
            Advertisement.Show(placementId, this);
        }

        public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
        {
            Debug.Log("Ad Load Failed");
        }

        public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
        {
            Debug.Log("Ad Show Failed");
        }

        public void OnUnityAdsShowStart(string placementId)
        {
            throw new System.NotImplementedException();
        }

        public void OnUnityAdsShowClick(string placementId)
        {
            throw new System.NotImplementedException();
        }

        public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
        {
            if (placementId.Equals(_adUnitId) && showCompletionState.Equals(UnityAdsCompletionState.COMPLETED))
            {
                // reward player
                _gameManager.ContinueGame();
            }
        }

        public void ShowAd(GameManager gameManager)
        {
            _gameManager = gameManager;

            Advertisement.Load(_adUnitId, this);
        }
    }
}


