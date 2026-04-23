using UnityEngine;
using UnityEngine.InputSystem;

public class ResupplyShip : MonoBehaviour
{
    public GameObject player;
    private InputManager _input;
    private MissileLocking _missile;
    
    
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        _input = InputManager.Instance;
        _input.GetSupplies.performed += Resupply;
    }

    
    

    private void Resupply(InputAction.CallbackContext context)
    {
        
        Health health = player.GetComponent<Health>();
        health.Heal();
        _missile = player.GetComponent<MissileLocking>();
        _missile.MissileReload();
    }
}
