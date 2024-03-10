using MiniIT.COMPONENTS;
using MiniIT.MODEL;
using UnityEngine;

namespace MiniIT.OBJECT
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Asteroid : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rigidbodyAsteroid;
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Sprite[] sprites;

        [SerializeField] public float size = 1f;
        [SerializeField] public float minSize = 0.5f;
        [SerializeField] public float maxSize = 2f;

        [SerializeField] private PlaySoundsComponent sound;
        
        private AsteroidSpawner asteroidSpawner;
    
        private void Start()
        {
            spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
            transform.eulerAngles = new Vector3(0f, 0f, Random.value * 360f);

            transform.localScale = Vector3.one * size;
            rigidbodyAsteroid.mass = size;

            asteroidSpawner = FindObjectOfType<AsteroidSpawner>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ball"))
            {
                if (size * 0.5f > minSize)
                {
                    CreateSplit();
                    CreateSplit();
                }
            
                GameSession.Instance.allAster -= 1;
                GameSession.Instance.AsteroidDestroyed(this);
                sound.PlaySound("Destroy");

                Destroy(gameObject);
            }
        }

        private Asteroid CreateSplit()
        {
            Vector2 position = transform.position;
            position += Random.insideUnitCircle * 0.5f;

            Asteroid half = Instantiate(this, position, asteroidSpawner.transform.rotation);
            half.size = size * 0.5f;
            GameSession.Instance.allAster += 1;

            return half;
        }

    }
}
