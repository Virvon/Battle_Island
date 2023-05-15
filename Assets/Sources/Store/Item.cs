using UnityEngine;
using BattleIsland.Menu;
using BattleIsland.SaveData;

public class Item : MonoBehaviour
{
    [SerializeField] private GameObject _skinPrefab;
    [SerializeField] private int _price;
    [SerializeField] private string _saveKey;

    private Skin _skin;

    public int Price => _price;
    public bool IsBuyed { get; private set; } = false;
    public GameObject Skin => _skinPrefab;

    private void OnEnable()
    {
        Load(_saveKey);

        _skin = GetComponentInChildren<Skin>();

        _skin.gameObject.SetActive(false);

        if (_price == 0)
            IsBuyed = true;
    }

    public void Activate(Vector3 position)
    {
        _skin.gameObject.SetActive(true);
        _skin.transform.position = position;
    }

    public void Deactivate()
    {
        _skin.gameObject.SetActive(false);
    }

    public bool TrySecelct(Player player)
    {
        if (IsBuyed == false)
            TryBuy(player);

        return IsBuyed;
    }

    private void TryBuy(Player player)
    {
        if (player.TryGetMoney(Price))
        {
            IsBuyed = true;
            Save(_saveKey);
        }
    }

    private void Save(string key)
    {
        SaveManger.Save(key, CreateSaveSnapshot());
    }

    private void Load(string key)
    {
        ItemPofile profile = SaveManger.Load<ItemPofile>(key);

        IsBuyed = profile.IsBuyed;
    }

    private ItemPofile CreateSaveSnapshot()
    {
        ItemPofile data = new ItemPofile();

        data.IsBuyed = IsBuyed;

        return data;
    }
}
