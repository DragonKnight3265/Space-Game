using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class PlayerSystems : MonoBehaviour
{
    public static PlayerSystems Instance;
    [SerializeField] private ShipStats ship;
    
    
    
    void Start()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        ship.currentHealth = 3;
        ship.currentShield = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
        if (ship.currentHealth <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    
    
    
    
    
}
