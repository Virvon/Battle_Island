using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoresOpener : MonoBehaviour
{
    [SerializeField] private Store[] _stores;
    [SerializeField] private Store _openOnStart;

    private Store _selectStore;

    private void Start() => Open(_openOnStart);

    public void Open(Store targetStore)
    {
        foreach(var store in _stores)
        {
            

            if(store == targetStore)
            {
                store.Open();
                _selectStore = store;
            }
            else
            {
                store.Close();
            }
        }
    }
}
