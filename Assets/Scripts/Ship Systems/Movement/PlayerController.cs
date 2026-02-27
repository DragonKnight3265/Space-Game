using Unity.Mathematics.Geometry;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] ShipStats _ship;
    private InputManager _input;
    private CharacterController _controller;
    private float _moveSpeed = 10;
    public int Health;
    public int Shield;
    void Start()
    {
        _input = InputManager.Instance;
        _controller = GetComponent<CharacterController>();
        Health = _ship.currentHealth = 3;
        Shield = _ship.currentShield = 2;
    }
    void Update()
    {
        HandleMovement(Time.deltaTime);
    }
    
    private void HandleMovement(float delta)
    {
        Vector3 moveDir = (_input.Move.x * transform.right) + (_input.Move.y * transform.forward);
        _controller.Move(moveDir * (_ship.playerSpeed * Time.deltaTime));
    }

    private void MovementShip(float delta)
    {
        _moveSpeed = Mathf.Clamp(_moveSpeed, 0, 10);

        // if current speed < max allowed speed
        if (_input.Move.x > 1)
        {
            
        }
        
        
    }
    
    
    
}
