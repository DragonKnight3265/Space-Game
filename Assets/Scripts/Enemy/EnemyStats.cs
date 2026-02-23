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
    
     //Movement
    public float moveSpeed;
    public float turnSpeed;
    
    //Search for Player
    public float sightRadius;
    public float sightDistance;
    public float attackDistance;
    public float agroDistance;
    public float searchRange;
    public float minDot;
    public float moveToPlayerBias;

    //misc
    public int pointsAmount;
}
