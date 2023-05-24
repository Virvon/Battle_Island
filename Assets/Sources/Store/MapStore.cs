public class MapStore : Store
{
    public static string SelectMap { get; private set; }

    private void OnDisable()
    {
        SelectMap = ((MapItem)SelectItem).Name;
    }

    protected override void LoadStaticItem()
    {
        foreach(var item in Items)
        {
            if (((MapItem)item).Name == SelectMap)
                SelectItem = item;
        }
    }
}
