using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    
    private Controls _controls;
    
    public Vector2 Move {get; private set;}
    public Vector2 Look {get; private set;}
    
    public InputAction FireAction {get; private set;}
    public InputAction MissileFire {get; private set;}
    
    public bool FireDown {get; private set;}
    public bool MissileDown {get; private set;}
    public bool MissileLaunch {get; private set;}
    

    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        
        _controls = new Controls();
        _controls.Enable();
        FireAction = _controls.Locomotion.Fire;
        MissileFire = _controls.Locomotion.Missile;
    }

    void Start()
    {
        _controls.Locomotion.Fire.performed += context => FireDown = true;
        _controls.Locomotion.Fire.canceled += context => FireDown = false;
        
        _controls.Locomotion.MissileLock.performed += context => MissileDown = true;
        _controls.Locomotion.MissileLock.canceled += context => MissileDown = false;
        
        _controls.Locomotion.Missile.performed += context => MissileLaunch = true;
        _controls.Locomotion.Missile.canceled += context => MissileLaunch = false;
        
        
        _controls.Locomotion.Move.performed += context => Move = context.ReadValue<Vector2>();
        _controls.Locomotion.Look.performed += context => Look = context.ReadValue<Vector2>();
    }

    
    void Update()
    {
        
    }
}
