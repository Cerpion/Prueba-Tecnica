using UnityEngine;

public class ParabolicProjectile : Projectile
{
    [SerializeField]private Rigidbody _rigidbody;
    [SerializeField]private float _height;
    [SerializeField]private float _gravity;
    [SerializeField]private float _distance;

    private Vector3 start;
    private Vector3 end;

    [SerializeField] private AudioSource _audio;
    [SerializeField] private AudioClip _bounce;
    [SerializeField] private AudioClip _shoot;

    protected override void DoStart()
    {
        start = transform.position;
        end = transform.position + transform.forward * _distance;
        end.y = 0;

        _rigidbody.velocity = CalculeVelocity();
        _audio.PlayOneShot(_shoot);
    }

    protected override void DoMove()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        _audio.PlayOneShot(_bounce);

    }

    private Vector3 CalculeVelocity()
    {
        var p = end - start;

        float x,y,z;

        y = Mathf.Sqrt(-2 * _gravity * _height);
        x = p.x / ((-y / _gravity) + Mathf.Sqrt(2 * (p.y - _height) / _gravity));
        z = p.z / ((-y / _gravity) + Mathf.Sqrt(2 * (p.y - _height) / _gravity));


        return new Vector3(x, y, z);
    }

    protected override void DoDestroy()
    {

    }

}

