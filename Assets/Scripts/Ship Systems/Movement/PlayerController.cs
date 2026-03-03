using Unity.Mathematics.Geometry;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] ShipStats _ship;
    private InputManager _input;
    private CharacterController _controller;
    void Start()
    {
        _input = InputManager.Instance;
        _controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        HandleMovement(Time.deltaTime);
    }
    
    private void HandleMovement(float delta)
    {
        Vector3 moveDir = (_input.Move.x * transform.right) + (_input.Move.y * transform.forward);
        _controller.Move(moveDir * (_ship.moveSpeed * Time.deltaTime));
    }

    private void MovementShip(float delta)
    {
        _ship.moveSpeed = Mathf.Clamp(_ship.moveSpeed, 0, 10);

        // if current speed < max allowed speed
        if (_input.Move.x > 1)
        {
            
        }
        
        
    }
    
    
    
}
