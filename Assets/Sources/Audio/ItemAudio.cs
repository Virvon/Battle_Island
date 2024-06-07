using BattleIsland.GameLogic.Store;
using System.Collections.Generic;
using UnityEngine;

namespace BattleIsland.Audio
{
    public class ItemAudio : MonoBehaviour
    {
        [SerializeField] private AudioSource _sellAudio;
        [SerializeField] private Store[] _stores;

        private List<Item> _items;

        private void OnEnable()
        {
            _items = new List<Item>();

            foreach (var store in _stores)
            {
                var items = store.GetComponentsInChildren<Item>();

                foreach (var item in items)
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

        private void PlayAudio()
        {
            _sellAudio.Play();
        }
    }
}