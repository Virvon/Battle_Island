using UnityEngine;
using UnityEngine.UI;

public class MapItem : Item
{
    [SerializeField] private SceneNames _name;
    [SerializeField] private Image _image;

    public SceneNames Name => _name;

    private void OnEnable() => Deactivate();

    public override void Activate(Vector3 position)
    {
        _image.GetComponent<RectTransform>().anchoredPosition = position;
        _image.enabled = true;
    }

    public override void Deactivate() => _image.enabled = false;
}
