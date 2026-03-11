using System;
using UnityEngine;
public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] CharacterStats stats;
    
    int _currentHealth;
    int _currentShield;
    public SceneChanger sceneChanger;
    
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
            if (_currentShield < 0)
            {
                _currentHealth += _currentShield;
                _currentShield = 0;
            }
            Debug.Log(gameObject.name + "took " + damage + " shield damage");
        }
        else
        { 
            _currentHealth -= damage;
            Debug.Log(gameObject.name + "took " + damage + " hull damage");
        }
        
        if (_currentHealth <= 0)
        {
            if (CompareTag("Player") == true)
            {
                sceneChanger.defeated=true;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
