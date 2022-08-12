using UnityEngine;

public class AntiGravityProjectile: Projectile
{

    private Rigidbody _rigidbody;
    [SerializeField] private Rigidbody _myRigidbody;

    [SerializeField] private AudioSource _audio;
    [SerializeField] private AudioClip _shoot;

    protected override void DoStart()
    {
        _myRigidbody.velocity = _myTransform.forward * _speed;
        _audio.PlayOneShot(_shoot);

    }

    protected override void DoMove()
    {

        if (_rigidbody == null)
        {
            return;
        }

        _rigidbody.AddForce(-2 * Physics.gravity, ForceMode.Acceleration);
    }

    protected override void DoDestroy()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            Debug.Log(collision.transform.name);
            _rigidbody = collision.rigidbody;
        }
    }

}