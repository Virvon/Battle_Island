using Assets.Sources.Infrastructure.Views;
using TMPro;
using UnityEngine;

namespace Assets.Sources.GameLogic.Enemy
{
    [RequireComponent(typeof(TextMeshPro))]
    public class NamePanel : MonoBehaviour
    {
        [SerializeField] private Vector3 _offset;
        [SerializeField] private Vector3 _rotation;

        private MovementObject _parent;

        public void Init(MovementObject parent)
        {
            _parent = parent;

            transform.rotation = Quaternion.Euler(_rotation);
            OnPositionChanged();

            GetComponent<TextMeshPro>().text = _parent.Name;

            _parent.PositionChanged += OnPositionChanged;
        }

        private void OnDisable() =>
            _parent.PositionChanged -= OnPositionChanged;

        private void OnPositionChanged() =>
            transform.position = _parent.transform.position + _offset;
    }
}