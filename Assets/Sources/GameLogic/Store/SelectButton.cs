using UnityEngine;
using UnityEngine.UI;

namespace BattleIsland.GameLogic.Store
{
    [RequireComponent(typeof(Image))]
    public class SelectButton : MonoBehaviour
    {
        [SerializeField] private Image _activeButton;
        [SerializeField] private Image _deactiveButton;

        private Image _image;

        private void Awake()
        {
            _image = GetComponent<Image>();
        }

        public void Activate()
        {
            _image.sprite = _activeButton.sprite;
        }

        public void Deactivate()
        {
            _image.sprite = _deactiveButton.sprite;
        }
    }
}