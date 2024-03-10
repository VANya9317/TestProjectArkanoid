using MiniIT.UI.LEVELSLOADER;
using UnityEngine;
using UnityEngine.Rendering;

namespace MiniIT.UTILS
{
    public static class MainGOsUtils
    {
        private const string cameraTag = "MainCamera";
        private const string canvasTag = "MainUICanvas";
        private const string globalVolumeTag = "GlobalVolume";

        private static Camera mainCamera;
        private static Canvas mainCanvas;
        private static LevelLoader levelLoader;
        private static Volume globalVolume;
        
        public static Camera GetMainCamera()
        {
            if (mainCamera != null) return mainCamera;
            
            var cameras = Object.FindObjectsOfType<Camera>();
            foreach (var camera in cameras)
            {
                if(!camera.CompareTag(cameraTag)) continue;
                mainCamera = camera;
                return mainCamera;
            }
            return default;
        }

        public static LevelLoader GetLevelLoader()
        {
            if (levelLoader != null) return levelLoader;

            return levelLoader = Object.FindObjectOfType<LevelLoader>();
        }

        public static Canvas GetMainCanvas()
        {
            if (mainCanvas != null) return mainCanvas;
            
            return mainCanvas = GameObject.FindWithTag(canvasTag).GetComponent<Canvas>();
        }
        
        public static Volume GetGlobalVolume()
        {
            if (globalVolume != null) return globalVolume;
            
            return globalVolume = GameObject.FindWithTag(globalVolumeTag).GetComponent<Volume>();
        }
        
    }
}