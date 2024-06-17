using BattleIsland.Infrastructure.View;
using BattleIsland.Infrastructure.View.Weapon;
using UnityEngine;

namespace BattleIsland.GameLogic.Spawner
{
    public class WeaponsSpawner : MonoBehaviour
    {
        [SerializeField] private WeaponView _weaponPrefab;

        public void CreateWeapon(MovementObject parent)
        {
            WeaponView weapon = Instantiate(_weaponPrefab, parent.transform.position, Quaternion.identity, transform);

            weapon.Init(parent, parent.ShootPoint);
        }
    }
}