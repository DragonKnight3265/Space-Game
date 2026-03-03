using UnityEngine;

[CreateAssetMenu(fileName = "ShipStats", menuName = "Scriptable Objects/ShipStats")]
public class ShipStats : CharacterStats
{
    
    [Header("Ship Weapons")]
    public int maxMissiles;
    public float missileRange;
    public float missileSpeed;
    public float missileTurnSpeed;
    public float lockTime;
    public float lockTimeNeeded;
}
