using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsSpawner : MonoBehaviour
{
    [SerializeField] private WeaponView _weaponPrefab;

    public void CreateWeapon(MovementObject parent)
    {
        WeaponView weapon = Instantiate(_weaponPrefab, parent.transform.position, Quaternion.identity, transform);

        weapon.Init(parent, parent.ShootPoint);
    }
}
