using UnityEngine;

[CreateAssetMenu(fileName = "ShipStats", menuName = "Scriptable Objects/ShipStats")]
public class ShipStats : ScriptableObject
{
    [Header("Ship Movement")] 
    public float maxSpeed;
    public float maxTurnSpeed;
    public float maxAcceleration;
    public float playerSpeed;
    
    
    [Header("Ship Weapons")]
    public float lazerFireRate;
    public float lazerRange;
    public int maxMissiles;
    public float missileRange;
    public float missileSpeed;
    public float missileTurnSpeed;
    public float lockTime;
    public float lockTimeNeeded;
    
    [Header("Ship Health")]
    public int maxHealth;
    public int maxShield;
    public int currentHealth;
    public int currentShield;
}
