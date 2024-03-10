using UnityEngine;

namespace MiniIT.UTILS
{
    public static class WindowUtils
    {
        public static void CreateWindow(string resourcePath)
        {
            GameObject window = Resources.Load<GameObject>(resourcePath);

            Canvas canvas = MainGOsUtils.GetMainCanvas();
            Object.Instantiate(window, canvas.transform);
        }
        
        public static void CreateCanvasWindow(string resourcePath, Canvas canvas)
        {
            GameObject window = Resources.Load<GameObject>(resourcePath);

            Object.Instantiate(window, canvas.transform);
        }
    }
}