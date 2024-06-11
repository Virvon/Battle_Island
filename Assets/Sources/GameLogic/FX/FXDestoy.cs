using UnityEngine;

namespace BattleIsland.GameLogic.FX
{
    public class FXDestoy : MonoBehaviour
    {
        [SerializeField] private float _delay = 3f;

        private void Start() =>
            Destroy(gameObject, _delay);
    }
}