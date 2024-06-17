using Assets.Sources.GameLogic.Enemy;
using Assets.Sources.Infrastructure.Views;
using UnityEngine;

namespace Assets.Sources.GameLogic.Spawners
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