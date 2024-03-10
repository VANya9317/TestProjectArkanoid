using MiniIT.COMPONENTS;
using UnityEngine;
using UnityEngine.Serialization;

namespace MiniIT.OBJECT
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rigidbodyBall;
        [SerializeField] private float speed = 100.0f;
        [SerializeField] private PlaySoundsComponent sound;

        private void Start () 
        {
            rigidbodyBall.velocity = Vector2.up * speed;	
        }
    
        private void OnCollisionEnter2D(Collision2D col) 
        {
            sound.PlaySound("Tap");
            if (col.gameObject.name == "Player") 
            {
                Vector2 newDirection = new Vector2 (HitFactor (transform.position, col.transform.position, col.collider.bounds.size.x), 1).normalized;
                rigidbodyBall.velocity = newDirection * speed;
            }
        }

        private float HitFactor(Vector2 ballPos, Vector2 racketPos, float racketWidth) 
        {
            return (ballPos.x - racketPos.x) / racketWidth;
        }
    }
}
