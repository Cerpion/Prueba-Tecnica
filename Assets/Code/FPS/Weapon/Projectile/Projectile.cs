using System.Collections;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField] protected float _speed;
    [SerializeField] protected float _timeToDestroy;
    protected Transform _myTransform;

    [SerializeField] private ProjectileID _iD;

    public string Id { get => _iD.Value; }


    private void Start()
    {
        _myTransform = transform;

        DoStart();
        StartCoroutine(DestroyIn(_timeToDestroy));
    }

    protected abstract void DoStart();

    private void FixedUpdate()
    {
        DoMove();
    }

    protected abstract void DoMove();



    private void OnTriggerEnter(Collider other)
    {
       // var damagable = other.GetComponent<Damageable>();
       // damagable.AddDamage(1);

    }


    private IEnumerator DestroyIn(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        DestroyProjectile();
    }

    private void DestroyProjectile()
    {
        DoDestroy();
        Destroy(this.gameObject);
    }

    protected abstract void DoDestroy();

    public void AddDamage(int amount)
    {
        DestroyProjectile();
    }
}
