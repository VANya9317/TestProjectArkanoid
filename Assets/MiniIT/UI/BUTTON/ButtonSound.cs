using MiniIT.UTILS;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MiniIT.UI.BUTTON
{
    public class ButtonSound : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private AudioClip audioClip;
        private AudioSource audioSource;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            if (audioSource == null)
            {
                audioSource = AudioUtils.FindSfxSource();
            }

            audioSource.PlayOneShot(audioClip);
        }
    }
}