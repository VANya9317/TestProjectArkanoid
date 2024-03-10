using UnityEngine;

namespace MiniIT.OBJECT
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Vector2 playerDirection;
        [SerializeField] private Rigidbody2D playerRigidbody;
        [SerializeField] private float playerSpeed = 10f;
    
        public void SetDirection(Vector2 direction)
        {
            playerDirection = direction;
        }
    
        private void FixedUpdate()
        {
            var xVelocity = playerDirection.x * playerSpeed;
            playerRigidbody.velocity = new Vector2(xVelocity, 0);
        }
    }
}
