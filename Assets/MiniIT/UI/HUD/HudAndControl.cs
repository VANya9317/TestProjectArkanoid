using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MiniIT.UI.HUD
{
    public class HudAndControl  : MonoBehaviour
    {
        private void Awake()
        {
            LoadUIs();
        }

        private void LoadUIs()
        {
            SceneManager.LoadScene("Hud", LoadSceneMode.Additive);
            LoadOnScreenControls();
        }
        
        [Conditional("USE_ONSCREEN_CONTROLS")]
        private void LoadOnScreenControls()
        {
            SceneManager.LoadScene("Controls", LoadSceneMode.Additive);
        }
    }
}