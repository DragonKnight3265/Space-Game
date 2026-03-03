using UnityEngine;

public abstract class CharacterStats : ScriptableObject
{
    [Header("Ship Health")]
    public int maxHealth;
    public int maxShield;
    public int currentHealth;
    public int currentShield;
    
    [Header("Ship Movement")] 
    public float maxSpeed;
    public float maxTurnSpeed;
    public float maxAcceleration;
    public float moveSpeed;
    public float turnSpeed;
    [Header("Ship Weapons")]
    public float lazerRange;
    public int weaponDamage;
    public float weaponChargeNeeded;
    public float weaponCharge;
}
