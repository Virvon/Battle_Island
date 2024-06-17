using Assets.Sources.GameLogic.Store;
using UnityEngine;

namespace BattleIsland.GameLogic.Store
{
    public class SkinStore : Assets.Sources.GameLogic.Store.Store
    {
        public static GameObject SelectSkin { get; private set; }

        private void OnDisable()
        {
            if (SelectedItem != null)
                SelectSkin = ((SkinItem)SelectedItem).Skin;
        }

        protected override Item LoadStaticItem()
        {
            foreach (var item in Items)
            {
                if (((SkinItem)item).Skin == SelectSkin)
                    return item;
            }

            return null;
        }

        protected override void SetSelectItem(Item item) =>
            SelectSkin = ((SkinItem)item).Skin;
    }
}