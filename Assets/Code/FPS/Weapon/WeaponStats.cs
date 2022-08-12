using UnityEngine;

[CreateAssetMenu(fileName = "WeaponStats", menuName = "ScriptableObjects/Create WeaponStats", order = 1)]

public class WeaponStats : ScriptableObject
{
    public ProjectileID ProyectileId;
    public float FireRateInSeconds;
    public Color WeaponColor;


}
