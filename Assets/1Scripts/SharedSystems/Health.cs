using UnityEngine;
using Random = UnityEngine.Random;
public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] CharacterStats stats;
    
    public int _currentHealth;
    public int _currentShield;
    int _maxHealth;
    int _maxShield;
    private int healing;
    private int energy;
    
    private void Awake()
    {
        _currentHealth = stats.maxHealth;
        _currentShield = stats.maxShield;
        _maxHealth = stats.maxHealth;
        _maxShield = stats.maxShield;
    }

    public void Heal()
    {
        healing = Random.Range(1,5); 
        energy = Random.Range(0,4);
        _currentHealth += healing;
        _currentHealth = Mathf.Min(_currentHealth, _maxHealth);
        Debug.Log("Healed "+healing);
        _currentShield += energy;
        _currentShield = Mathf.Min(_currentShield, _maxShield);
        Debug.Log("Recharged "+energy);
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
                Destroy(gameObject);
        }
    }
}
