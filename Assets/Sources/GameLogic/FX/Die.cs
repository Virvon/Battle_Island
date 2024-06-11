using BattleIsland.Infrastructure.View;
using UnityEngine;

namespace BattleIsland.GameLogic.FX
{
    [RequireComponent(typeof(MovementObject))]
    public class Die : MonoBehaviour
    {
        [SerializeField] private GameObject _dieFX;

        private MovementObject _movementObject;

        private void OnEnable()
        {
            _movementObject = GetComponent<MovementObject>();

            _movementObject.Died += SpawnDieFX;
        }

        private void OnDisable()
        {
            _movementObject.Died -= SpawnDieFX;
        }

        private void SpawnDieFX()
        {
            Instantiate(_dieFX, transform.position, Quaternion.identity);
        }
    }
}