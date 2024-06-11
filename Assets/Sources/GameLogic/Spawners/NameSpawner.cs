using BattleIsland.GameLogic.Enemy;
using BattleIsland.Infrastructure.View;
using UnityEngine;

namespace BattleIsland.GameLogic.Spawner
{
    public class NameSpawner : MonoBehaviour
    {
        [SerializeField] private NamePanel _namePrefab;

        public void CreateName(MovementObject parent)
        {
            var name = Instantiate(_namePrefab, parent.transform.position, Quaternion.identity, transform);

            name.Init(parent);
        }
    }
}