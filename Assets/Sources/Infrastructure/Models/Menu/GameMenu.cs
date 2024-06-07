using System;

namespace BattleIsland.Infrustructure.Model
{
    public class GameMenu : Menu
    {
        public event Action ResultPanelOpened;

        public void OpenResultPanel() =>
            ResultPanelOpened?.Invoke();
    }
}
