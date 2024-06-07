using TMPro;
using UnityEngine;

namespace BattleIsland.GameLogic.Learning
{
    [RequireComponent(typeof(LearnPanel))]
    public class LearnInfoColor : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        private LearnPanel _learnPanel;

        private void OnEnable()
        {
            _learnPanel = GetComponent<LearnPanel>();

            _learnPanel.ColorChanged += OnColorChanged;
        }

        private void OnDisable() =>
            _learnPanel.ColorChanged -= OnColorChanged;

        private void OnColorChanged(Color color) =>
            _text.color = new Color(_text.color.r, _text.color.g, _text.color.b, color.a);
    }
}