using System;

namespace Assets.Sources.Infrastructure.Models
{
    public class GameMenu : Menu
    {
        public event Action ResultPanelOpened;

        public void OpenResultPanel() =>
            ResultPanelOpened?.Invoke();
    }
}
