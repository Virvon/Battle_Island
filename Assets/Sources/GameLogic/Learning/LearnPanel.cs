using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace BattleIsland.GameLogic.Learning
{
    [RequireComponent(typeof(Image))]
    public class LearnPanel : MonoBehaviour
    {
        [SerializeField] float _animationSpeed;

        private Color _color;
        private Image _image;
        private Coroutine _coroutine;

        public event Action<Color> ColorChanged;

        private void Start()
        {
            _image = GetComponent<Image>();
            _color = _image.color;
            _image.color = new Color(_image.color.a, _image.color.g, _image.color.b, 0);
            ColorChanged?.Invoke(_image.color);
        }

        public void Open()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(ChangeCollor(_color, _animationSpeed));
        }

        public void Close()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(ChangeCollor(new Color(_image.color.a, _image.color.g, _image.color.b, 0), _animationSpeed));
        }

        private IEnumerator ChangeCollor(Color targeColor, float speed)
        {
            float time = 0;
            Color startColor = _image.color;

            while (_image.color != targeColor)
            {
                time += Time.deltaTime;

                _image.color = Color.Lerp(startColor, targeColor, time / speed);

                ColorChanged?.Invoke(_image.color);

                yield return null;
            }
        }
    }
}