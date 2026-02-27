using System;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] EnemyStats _ship;
    int health;
    int shield;
    private void Awake()
    {
        health = _ship.health;
        shield = _ship.shield;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Player took Damage");
        
        if (_ship.health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    
    
}
