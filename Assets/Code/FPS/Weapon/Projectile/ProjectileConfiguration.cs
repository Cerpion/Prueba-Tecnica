using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = ("ProjectileConfiguration"), menuName = ("Factory/ProjectileConfig"), order = 0)]
public class ProjectileConfiguration : ScriptableObject
{
    public Projectile[] _projectile;
    private Dictionary<string, Projectile> _projectilesConjunt;

    private void Awake()
    {
        _projectilesConjunt = new Dictionary<string, Projectile>();

        foreach (var projectil in _projectile)
        {
            _projectilesConjunt.Add(projectil.Id, projectil);
        }

    }

    public Projectile GetProjectile(string iD)
    {
        return _projectilesConjunt[iD];
    }

}
