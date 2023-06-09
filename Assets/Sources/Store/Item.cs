using UnityEngine;
using BattleIsland.Menu;
using BattleIsland.SaveData;
using System;

public abstract class Item : MonoBehaviour
{
    [SerializeField] private int _price;
    [SerializeField] private string _saveKey;

    public int Price => _price;
    public bool IsBuyed { get; private set; }

    public event Action Selled;

    private void Awake()
    {
        Load(_saveKey);

        if (_price == 0)
            IsBuyed = true;

    }

    public abstract void Activate(Vector3 position);

    public abstract void Deactivate();

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
            Selled?.Invoke();
            Save(_saveKey);
        }
    }

    private void Save(string key)
    {
        SaveManager.Save(key, CreateSaveSnapshot());
    }

    private void Load(string key)
    {
        ItemPofile profile = SaveManager.Load<ItemPofile>(key);

        IsBuyed = profile.IsBuyed;
    }

    private ItemPofile CreateSaveSnapshot()
    {
        ItemPofile data = new ItemPofile();

        data.IsBuyed = IsBuyed;

        return data;
    }
}
