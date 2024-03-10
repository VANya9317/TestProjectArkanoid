using MiniIT.UTILS;

namespace MiniIT.UI.MENU
{
    public class StartMenu : AnimatedMenu
    {
        public void OnMainOpen()
        {
            MainGOsUtils.GetLevelLoader().LoadLevel("Game");
        }
    }
}