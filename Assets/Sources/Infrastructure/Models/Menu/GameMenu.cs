using System;

namespace BattleIsland.Model
{
    public class GameMenu : Menu
    {
        public event Action ResultPanelOpened;

        public void OpenResultPanel() =>
            ResultPanelOpened?.Invoke();
    }
}
