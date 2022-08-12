using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlot : MonoBehaviour
{
    [SerializeField] WeaponStats _weaponStats;
    [SerializeField] Transform _weapon;

    public WeaponStats GetWeapon()
    {
        return _weaponStats;
    }

    private void Update()
    {
        _weapon.Rotate(Vector3.up);
    }

}
