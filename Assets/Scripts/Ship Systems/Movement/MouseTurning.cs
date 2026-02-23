using UnityEngine;

public class MouseLook : MonoBehaviour
{
    private InputManager _input;
    
    [SerializeField] private Transform playerParent;
    [SerializeField] private float sensitivity = 10;

    private float _playerRot;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
        float mouseinput = _input.Look.x * sensitivity * delta;
        
        transform.localRotation = Quaternion.Euler(_playerRot, 0f, 0f);
        playerParent.Rotate(Vector3.up, mouseinput);
    }
    
}
//Quaternion targetRotation = Quaternion.LookRotation(lookPos, Vector3.up);
      //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, sensitivity * delta);
      