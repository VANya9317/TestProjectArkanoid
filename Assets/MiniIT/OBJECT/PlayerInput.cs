using UnityEngine;
using UnityEngine.InputSystem;

namespace MiniIT.OBJECT
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private Player player;
        
        public void OnMovement(InputAction.CallbackContext context)
        {
            var direction = context.ReadValue<Vector2>();
            player.SetDirection(direction);
        }
    }
}