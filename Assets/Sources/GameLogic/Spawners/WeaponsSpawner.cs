using Assets.Sources.Infrastructure.Views;
using Assets.Sources.Infrastructure.Views.Weapon;
using UnityEngine;

namespace Assets.Sources.GameLogic.Spawners
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