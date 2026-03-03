using UnityEngine;

public class MouseLook : MonoBehaviour
{
    private InputManager _input;
    [SerializeField] private Transform playerParent;
    [SerializeField] private ShipStats ship;
    private float _playerRot;
    
    void Start()
    {
        _input = InputManager.Instance;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        HandleLook(Time.deltaTime);
    }

    private void HandleLook(float delta)
    {
        float mouseinput = _input.Look.x * ship.turnSpeed * delta;
        
        transform.localRotation = Quaternion.Euler(_playerRot, 0f, 0f);
        playerParent.Rotate(Vector3.up, mouseinput);
    }
    
}
//Quaternion targetRotation = Quaternion.LookRotation(lookPos, Vector3.up);
      //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, sensitivity * delta);
      