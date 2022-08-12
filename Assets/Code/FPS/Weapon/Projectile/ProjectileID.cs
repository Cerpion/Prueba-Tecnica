using UnityEngine;

[CreateAssetMenu(fileName = ("Projectile"), menuName = ("Factory/ProjectileID"), order = 1)]
public class ProjectileID : ScriptableObject
{
    [SerializeField] private string _value;

    public string Value { get => _value; }
}
