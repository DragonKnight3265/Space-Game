using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "Scriptable Objects/EnemyStats")]
public class EnemyStats : CharacterStats
{ 
    [Header("Search For Player")]
    public float sightRadius;
    public float sightDistance;
    [Header("Attack Distance")]
    public float maxFireDistance;
    public float agroDistance;
    public float attackDistance;
    [Header("Random Movement")]
    public float searchRange;
    public float minDot;
    public float moveToPlayerBias;
    [Header("Misc")]
    public int pointsAmount;
}
