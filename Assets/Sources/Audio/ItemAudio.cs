using System.Collections.Generic;
using Assets.Sources.GameLogic.Store;
using UnityEngine;

namespace Assets.Sources.Audio
{
    public class ItemAudio : MonoBehaviour
    {
        [SerializeField] private AudioSource _sellAudio;
        [SerializeField] private Store[] _stores;

        private List<Item> _items;

        private void OnEnable()
        {
            _items = new();

            foreach (var store in _stores)
            {
                Item[] items = store.GetComponentsInChildren<Item>();

                if (items == null)
                    break;

                foreach (Item item in items)
                    _items.Add(item);
            }

            foreach (var item in _items)
                item.Selled += PlayAudio;
        }

        private void OnDisable()
        {
            foreach (var item in _items)
                item.Selled -= PlayAudio;
        }

        private void PlayAudio() =>
            _sellAudio.Play();
    }
}