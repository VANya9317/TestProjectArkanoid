using MiniIT.MODEL;
using MiniIT.UTILS;
using TMPro;
using UnityEngine;

namespace MiniIT.UI.MENU
{
    public class DeadMenu : AnimatedMenu
    {
        [SerializeField] private TextMeshProUGUI score;

        protected override void Start()
        {
            base.Start();
            score.text = FindObjectOfType<GameSession>().score.ToString();
        }
        
        public void ResetGame()
        {
            Close();
            MainGOsUtils.GetLevelLoader().LoadLevel("Game");
        }
    }
}