using UnityEngine;

public class SkinStore : Store
{
    public static GameObject SelectSkin { get; private set; }

    private void OnDisable()
    {
        SelectSkin = ((SkinItem)SelectItem).Skin;
    }

    protected override void LoadStaticItem()
    {
        foreach (var item in Items)
        {
            if (((SkinItem)item).Skin == SelectSkin)
                SelectItem = item;
        }
    }
}
