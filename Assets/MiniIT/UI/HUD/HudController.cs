using MiniIT.MODEL;
using TMPro;
using UnityEngine;

namespace MiniIT.UI.HUD
{
    public class HudController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI score;
        private void Update()
        {
            score.text = FindObjectOfType<GameSession>().score.ToString();
        }

        public void TapToStart()
        {
            GameSession.Instance.StartGame();
        }
    }
}