using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "Scriptable Objects/EnemyStats")]
public class EnemyStats : ScriptableObject
{ 
    
    
    //Health
    public int health;
    public int shield;
    
    //Weapons
    public float weaponRange;
    public float weaponDamage;
    public float weaponChargeTime;
    public float weaponChargeNeeded;
     //Movement
    public float moveSpeed;
    public float turnSpeed;
    
    //Search for Player
    public float sightRadius;
    public float sightDistance;
    //start attacking
    public float attackDistance;
    //Until they can't attack
    public float maxFireDistance;
    public float agroDistance;
    public float searchRange;
    public float minDot;
    public float moveToPlayerBias;

    //misc
    public int pointsAmount;
}
