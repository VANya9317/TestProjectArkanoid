using System;
using MiniIT.UTILS;
using UnityEngine;

namespace MiniIT.COMPONENTS
{
    public class PlaySoundsComponent : MonoBehaviour
    {
        [SerializeField] private AudioData[] sounds;
        [SerializeField] private AudioSource source;
        
        public void PlaySound(string id)
        {
            foreach (var audioData in sounds)
            {
                if (audioData.Id != id) continue;

                if (source == null)
                    source = AudioUtils.FindSfxSource();

                source.PlayOneShot(audioData.Clip);
                break;
            }
        }

        [Serializable]
        public class AudioData
        {
            [SerializeField] private string _id;
            [SerializeField] private AudioClip _clip;

            public string Id => _id;
            public AudioClip Clip => _clip;
        }
    }
}