using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace MiniIT.COMPONENTS
{
    public class ImageAnimation : MonoBehaviour
    {
        [SerializeField] [Range(1, 60)] private int frameRate = 10;
        [SerializeField] private UnityEvent<String> onComplete;
        [SerializeField] public AnimationClip[] clips;

        private Image rendererImage;
        private float secPerFrame;
        private float nextFrameTime;
        private int currentFrame;
        private bool isPlaying = true;
        private int currentClip;

        private void Start()
        {
            rendererImage = GetComponent<Image>();
            secPerFrame = 1f / frameRate;
            
            StartAnimation();
        }

        private void OnBecameVisible()
        {
            enabled = isPlaying;
        }
        private void OnBecameInvisible()
        {
            enabled = false;
        }

        public void SetClip(string clipName)
        {
            for (var i = 0; i < clips.Length; i++)
            {
                if (clips[i].Name == clipName)
                {
                    currentClip = i;
                    StartAnimation();
                    return;
                }
            }
            enabled = isPlaying = false;
        }

        private void StartAnimation()
        {
            nextFrameTime = Time.time;
            enabled = isPlaying = true;
            currentFrame = 0;
        }
        private void OnEnable()
        {
            nextFrameTime = Time.time;
        }

        private void Update()
        {
            if (nextFrameTime > Time.time) return;

            var clip = clips[currentClip];

            if (currentFrame >= clip.Sprites.Length)
            {
                if (clip.Loop)
                {
                    currentFrame = 0;
                }
                else
                {
                    enabled = isPlaying = clip.AllowNextClip;
                    clip.OnComplete?.Invoke();
                    onComplete?.Invoke(clip.Name);
                    
                    if (clip.AllowNextClip)
                    {
                        if (clip.NextClipName == "")
                        {
                            currentFrame = 0;
                            currentClip = (int)Mathf.Repeat(currentClip + 1, clips.Length);
                        }
                        else
                        {
                            for (var i = 0; i < clips.Length; i++)
                            {
                                if (clips[i].Name == clip.NextClipName)
                                {
                                    currentClip = i;
                                    currentFrame = 0;
                                }
                            }
                        }
                    }
                }
                
                return;
            }

            rendererImage.overrideSprite = clip.Sprites[currentFrame];
            nextFrameTime += secPerFrame;
            currentFrame++;
        }


        [Serializable]
        public class AnimationClip
        {
            [SerializeField] private string _name;
            [SerializeField] private Sprite[] _sprites;
            [SerializeField] private bool _loop;
            [SerializeField] private bool _allowNextClip;
            [SerializeField] private string _nextClipName;
            [SerializeField] private UnityEvent _onComplete;

            public string Name => _name;
            public Sprite[] Sprites => _sprites;
            public bool Loop => _loop;
            public bool AllowNextClip => _allowNextClip;
            public string NextClipName => _nextClipName;
            public UnityEvent OnComplete => _onComplete;
        }
    }
}