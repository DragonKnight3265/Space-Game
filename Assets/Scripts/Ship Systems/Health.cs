using System;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] ShipStats _ship;


    private void Awake()
    {
        _ship.currentHealth = _ship.maxHealth;
        _ship.currentShield =  _ship.maxShield;
    }
    public void TakeDamage(int damage)
    {
        _ship.currentHealth -= damage;
        Debug.Log("Player took Damage");
        
        if (_ship.currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    
    
}
