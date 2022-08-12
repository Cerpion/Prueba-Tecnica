using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    private float _remaininSecondsToBeAbleToShoot;
    [SerializeField] private Transform _projectileSpawnPosition;
    [SerializeField] private ProjectileConfiguration _proyectileConfiguration;
    [SerializeField] private ProyectileFactory _proyectileFactory;
    [SerializeField] private WeaponStats _currentWeapon;

    [SerializeField] private Material _weapon;


    [SerializeField] private Animator _playerAnimator;

    private void Awake()
    {
        _proyectileFactory = new ProyectileFactory(Instantiate(_proyectileConfiguration));
    }

    public void TryShoot()
    {
        if (_currentWeapon == null)
        {
            return;
        }

        _remaininSecondsToBeAbleToShoot -= Time.deltaTime;

        if (_remaininSecondsToBeAbleToShoot > 0)
        {
            return;
        }

        Shoot();

    }

    private void Shoot()
    {
        _playerAnimator.SetTrigger("Shoot");
        _remaininSecondsToBeAbleToShoot = _currentWeapon.FireRateInSeconds;
        _proyectileFactory.Create(_currentWeapon.ProyectileId.Value, _projectileSpawnPosition);
    }

    public void GetWeapon(WeaponStats newWeapon)
    {
        _currentWeapon = newWeapon;
        _weapon.color = newWeapon.WeaponColor;
    }

}
