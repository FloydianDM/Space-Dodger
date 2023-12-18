using UnityEngine;

namespace SpaceDodger
{
    public class AsteroidSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] asteroidPrefabs;
        [SerializeField] private float timeBetweenSpawns = 2f;
        [SerializeField] private Vector2 forceRange;

        private float _timer;
        private Camera _mainCamera;

        private void Start()
        {
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            ProcessTimer();
        }

        private void ProcessTimer()
        {
            _timer -= Time.deltaTime;

            if (_timer <= 0)
            {
                SpawnAsteroid();
                _timer += timeBetweenSpawns;
            }
        }

        private void SpawnAsteroid()
        {
            int screenSide = Random.Range(0,4);

            Vector2 spawnPoint = Vector2.zero;
            Vector2 travelDirection = Vector2.zero;

            switch (screenSide)
            {
                case 0:
                    spawnPoint.x = 0;
                    spawnPoint.y = Random.value;
                    travelDirection += new Vector2(1, Random.Range(-1,1));
                    break;
                case 1:
                    spawnPoint.x = 1;
                    spawnPoint.y = Random.value;
                    travelDirection += new Vector2(-1, Random.Range(-1,1)); 
                    break;
                case 2:
                    spawnPoint.x = Random.value;
                    spawnPoint.y = 0;
                    travelDirection += new Vector2(Random.Range(-1, 1), 1);
                    break;
                case 3:
                    spawnPoint.x = Random.value;
                    spawnPoint.y = 1;
                    travelDirection += new Vector2(Random.Range(-1, 1), -1);
                    break;
            }

            Vector2 worldSpawnPoint = _mainCamera.ViewportToWorldPoint(spawnPoint);

            GameObject randomAsteroid = asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)];
            GameObject asteroidInstance = Instantiate(randomAsteroid, worldSpawnPoint, Quaternion.Euler(0f, 0f, Random.Range(0, 360f)));
            Rigidbody asteroidRb = asteroidInstance.GetComponent<Rigidbody>();

            asteroidRb.velocity = travelDirection.normalized * Random.Range(forceRange.x, forceRange.y);
        }
    }
}


