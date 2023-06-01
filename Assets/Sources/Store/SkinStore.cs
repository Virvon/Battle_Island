using UnityEngine;

public class SkinStore : Store
{
    public static GameObject SelectSkin { get; private set; }

    private void OnDisable()
    {
        if(_selectItem != null)
            SelectSkin = ((SkinItem)_selectItem).Skin;
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

    protected override void SetSelectItem(Item item) => SelectSkin = ((SkinItem)item).Skin;
}
