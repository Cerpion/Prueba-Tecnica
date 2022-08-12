using UnityEngine;

public class AttractObjectsProjectile: Projectile
{

    [SerializeField] private Rigidbody _myRigidbody;
    private float _currenTime;
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _person;

    [SerializeField] private AudioSource _audio;
    [SerializeField] private AudioClip _shoot;
    [SerializeField] private AudioClip _area;

    [SerializeField] private bool _areaAudio;

    protected override void DoStart()
    {
        _myRigidbody.velocity = _myTransform.forward * _speed;
        _audio.PlayOneShot(_shoot);

    }

    protected override void DoMove()
    {

        ObtainObject(_currenTime);
        _currenTime = _currenTime + 300 * Time.deltaTime;

    }

    private void ObtainObject(float angle)
    {
        if (!_areaAudio)
        {
            _areaAudio = true;
            _audio.PlayOneShot(_area);
        }

        var colliders = Physics.OverlapSphere(transform.position, _radius, _person);

        foreach (var item in colliders)
        {
            var posX = transform.position.x + Mathf.Cos(angle * Mathf.Deg2Rad) * _radius;
            var posY = transform.position.y;
            var posZ = transform.position.z + Mathf.Sin(angle * Mathf.Deg2Rad) * _radius;

            var newPos = new Vector3(posX, posY, posZ);

            item.transform.position = newPos;
        }
    }

    protected override void DoDestroy()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _radius);
    }

}
