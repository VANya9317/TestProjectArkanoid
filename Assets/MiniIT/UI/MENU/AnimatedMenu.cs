using UnityEngine;

namespace MiniIT.UI.MENU
{
    public class AnimatedMenu : MonoBehaviour
    {
        private Animator animator;

        private static readonly int Show = Animator.StringToHash("Show");
        private static readonly int Hide = Animator.StringToHash("Hide");

        protected virtual void Start()
        {
            animator = GetComponent<Animator>();
            animator.SetTrigger(Show);
        }

        protected void Close()
        {
            animator.SetTrigger(Hide);
        }

        public virtual void OnCloseAnimationComplete()
        {
            Destroy(gameObject);
        }
    }
}