using UnityEngine;

namespace MiniIT.UTILS
{
    public abstract class AudioUtils
    {
        private const string SfxSourceTag = "SfxAudioSource";

        public static AudioSource FindSfxSource()
        {
            return GameObject.FindWithTag(SfxSourceTag).GetComponent<AudioSource>();
        }
    }
}
