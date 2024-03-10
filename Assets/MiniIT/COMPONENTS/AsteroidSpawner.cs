using MiniIT.MODEL;
using MiniIT.OBJECT;
using UnityEngine;

namespace MiniIT.COMPONENTS
{
    public class AsteroidSpawner : MonoBehaviour
    {
        [SerializeField] private Asteroid asteroidPrefab;
        [SerializeField] private float spawnDistance = 5f;
        [SerializeField] private int amountPerSpawn = 15;
        
        [Range(0f, 45f)]
        [SerializeField] private float trajectoryVariance = 15f;

        private void Start()
        {
            Spawn();
        }

        [ContextMenu("SpawnAsteroids")]
        private void Spawn()
        {
            for (int i = 0; i < amountPerSpawn; i++)
            { 
                Vector2 spawnDirection = Random.insideUnitCircle.normalized;
                Vector3 spawnPoint = spawnDirection * spawnDistance;

                spawnPoint += transform.position;

                float variance = Random.Range(-trajectoryVariance, trajectoryVariance);
                Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

                Asteroid asteroid = Instantiate(asteroidPrefab, spawnPoint, rotation, this.transform);
                asteroid.size = Random.Range(asteroid.minSize, asteroid.maxSize);

                GameSession.Instance.allAster = amountPerSpawn;
            }
        }
    }
}
