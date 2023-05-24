using UnityEngine;

public class ItemAudio : MonoBehaviour
{
    [SerializeField] private AudioSource _sellAudio;
    [SerializeField] private SkinStore _store;

    private Item[] _items;

    private void OnEnable()
    {
        _items = _store.GetComponentsInChildren<Item>();

        foreach (var item in _items)
            item.Selled += PlayAudio;
    }

    private void OnDisable()
    {
        foreach(var item in _items)
            item.Selled -= PlayAudio;
    }

    private void PlayAudio()
    {
        _sellAudio.Play();
    }
}
