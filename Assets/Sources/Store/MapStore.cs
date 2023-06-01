public class MapStore : Store
{
    public static string SelectMap { get; private set; }

    private void OnDisable()
    {
        if(_selectItem != null)
            SelectMap = ((MapItem)_selectItem).Name;
    }

    protected override Item LoadStaticItem()
    {
        foreach(var item in Items)
        {
            if (((MapItem)item).Name == SelectMap)
                return item;
        }

        return null;
    }

    protected override void SetSelectItem(Item item) => SelectMap = ((MapItem)item).Name;
}
