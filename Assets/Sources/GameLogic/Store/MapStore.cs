using Assets.Sources.Infrastructure.Models;

namespace Assets.Sources.GameLogic.Store
{
    public class MapStore : Store
    {
        public static SceneId SelectMap { get; private set; }

        private void OnDisable()
        {
            if (SelectedItem != null)
                SelectMap = ((MapItem)SelectedItem).Name;
        }

        protected override Item LoadStaticItem()
        {
            foreach (var item in Items)
            {
                if (((MapItem)item).Name == SelectMap)
                    return item;
            }

            return null;
        }

        protected override void SetSelectItem(Item item) =>
            SelectMap = ((MapItem)item).Name;
    }
}