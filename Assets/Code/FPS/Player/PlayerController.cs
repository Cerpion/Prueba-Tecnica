using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CameraMovement _cameraMovement;
    private Movement _movement;

    [Header ("Camera Options")]
    [SerializeField] private float _smoothCamera = 4;
    [SerializeField] private Transform _playerBody;
    [SerializeField] private Transform _playerHead;
    [SerializeField] private Vector2 _limitCamera;

    [Header("Weapon Options")]
    [SerializeField] private WeaponController _weaponController;
    [SerializeField] private Animator _playerAnimator;
    private WeaponStats _weapon;
    private bool _canChangeWeapon;

    [Header("Move Options")]
    [SerializeField] private float _speedMovement = 8;
    [SerializeField] private Rigidbody _rigidbody;
    private Transform _myTransform;

    private void Awake()
    {
        _myTransform = transform;
        _cameraMovement = new CameraMovement(_smoothCamera, _playerBody, _playerHead, _limitCamera);
        _movement = new Movement(_speedMovement, _rigidbody, _myTransform);
    }




    void Update()
    {
        _movement.DoMove();
        _cameraMovement.CameraMove();
        TryShooting();
        PickUpGun();
    }

    private void PickUpGun()
    {
        if (Input.GetKeyDown("e") && _canChangeWeapon)
        {
            _weaponController.GetWeapon(_weapon);
            _playerAnimator.SetBool("Weapon", true);
        }
    }

    public void TryShooting()
    {
        if (Input.GetMouseButton(0))
        {
            _weaponController.TryShoot();
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SlotWeapon"))
        {
            var alertWeapon = new AlertWeaponEvent(other.name);
            ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(alertWeapon);

            _weapon = other.GetComponent<WeaponSlot>().GetWeapon();
            _canChangeWeapon = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(new EventData(EventId.HideAlertWeapon));
        _weapon = null;
        _canChangeWeapon = false;
    }



}
