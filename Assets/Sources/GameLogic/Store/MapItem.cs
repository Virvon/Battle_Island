using BattleIsland.Infrustructure.Model;
using UnityEngine;
using UnityEngine.UI;

namespace BattleIsland.GameLogic.Store
{
    public class MapItem : Item
    {
        [SerializeField] private SceneId _name;
        [SerializeField] private Image _image;

        public SceneId Name => _name;

        private void OnEnable() => Deactivate();

        public override void Activate(Vector3 position)
        {
            _image.GetComponent<RectTransform>().anchoredPosition = position;
            _image.enabled = true;
        }

        public override void Deactivate() => _image.enabled = false;
    }
}