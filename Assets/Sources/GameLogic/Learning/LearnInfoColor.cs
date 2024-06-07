using TMPro;
using UnityEngine;

namespace BattleIsland.GameLogic.Learning
{
    [RequireComponent(typeof(LearnPanel))]
    public class LearnInfoColor : MonoBehaviour
    {
        private LearnPanel _learnPanel;
        private TextMeshProUGUI _text;

        private void OnEnable()
        {
            _text = GetComponentInChildren<TextMeshProUGUI>();
            _learnPanel = GetComponent<LearnPanel>();

            _learnPanel.ColorChanged += OnColorChanged;
        }

        private void OnDisable() =>
            _learnPanel.ColorChanged -= OnColorChanged;

        private void OnColorChanged(Color color) =>
            _text.color = new Color(_text.color.r, _text.color.g, _text.color.b, color.a);
    }
}