using System;
using UnityEngine.SceneManagement;
using UnityEngine;
public class Health : MonoBehaviour
{
    [SerializeField] CharacterStats stats;
    
    int _currentHealth;
    int _currentShield;
    
    private void Awake()
    {
        _currentHealth = stats.maxHealth;
        _currentShield = stats.maxShield;
    }
    
    public void TakeDamage(int damage)
    {
        if (_currentShield > 0)
        {
            _currentShield -= damage;
        }
        else
        { 
            _currentHealth -= damage;
        }
        if (_currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
