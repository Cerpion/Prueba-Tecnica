using UnityEngine;

public class ProyectileFactory
{
    [SerializeField] private ProjectileConfiguration _projectilePrefab;

    public ProyectileFactory(ProjectileConfiguration projectilePrefab)
    {
        _projectilePrefab = projectilePrefab;
    }

    public Projectile Create(string iD, Transform Startposition)
    {
        var prefabInstantiate = _projectilePrefab.GetProjectile(iD);
        var projectile = Object.Instantiate(prefabInstantiate, Startposition.position, Startposition.rotation);
        return projectile;
    }


}
