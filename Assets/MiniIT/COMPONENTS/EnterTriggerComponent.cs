using MiniIT.UTILS;
using UnityEngine;

namespace MiniIT.COMPONENTS
{
    public class EnterTriggerComponent : MonoBehaviour
    {
        [SerializeField] private string tagCollider;
        [SerializeField] private LayerMask layerCollider;
        [SerializeField] private EnterEvent action;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.IsInLayer(layerCollider)) return;
            if (!string.IsNullOrEmpty(tagCollider) && !string.IsNullOrEmpty(other.gameObject.tag) && !other.gameObject.CompareTag(tagCollider)) return;
            action?.Invoke(other.gameObject);
        }
    }
}