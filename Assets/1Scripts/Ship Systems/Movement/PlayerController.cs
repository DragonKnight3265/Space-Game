using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class Player : MonoBehaviour
{
    [SerializeField] ShipStats ship;
    
    private InputManager _input;
    private CharacterController _controller;
    private SceneChanger sceneChanger;
    private Health _health;
    private MissileLocking _missile;
    [SerializeField] public TMP_Text healthText;
    
    
    
    
    void Start()
    {
        _input = InputManager.Instance;
        _controller = GetComponent<CharacterController>();
        sceneChanger = FindFirstObjectByType<SceneChanger>();
        _health = GetComponent<Health>();
        _missile=GetComponentInChildren<MissileLocking>();
    }
    
    private void UpdateHealthText()
    {
        healthText.text = "Hull:"+_health._currentHealth + " " +
                          "Shield:"+_health._currentShield+"" +
                          "Missile Ammo:" + _missile.missileAmmo;
    }
    
    void Update()
    {
        //Return to Normal after
        if (LevelManager.instance.movingLevels)
            return;
        HandleMovement(Time.deltaTime);
        UpdateHealthText();
        if (_health._currentHealth <= 0)
        {
            sceneChanger.defeated = true;
            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Resupply"))
        {
            Health health = GetComponent<Health>();
            _health.Heal();
            MissileLocking missile = GetComponentInChildren<MissileLocking>();
            _missile.MissileReload();
            Destroy(other.gameObject);
        }
    }
    
    private void HandleMovement(float delta)
    {
        Vector3 moveDir = (_input.Move.x * transform.right) + (_input.Move.y * transform.forward);
        _controller.Move(moveDir * (ship.moveSpeed * Time.deltaTime));
    }

    private void MovementShip(float delta)
    {
        ship.moveSpeed = Mathf.Clamp(ship.moveSpeed, 0, 10);

        // if current speed < max allowed speed
        if (_input.Move.x > 1)
        {
            
        }
    }
}
