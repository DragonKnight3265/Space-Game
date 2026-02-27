using UnityEngine;
using UnityEngine.InputSystem;

public class Lazer : MonoBehaviour
{
    [SerializeField]private ShipStats _stats;
    [SerializeField] private Camera shootPosition;
    [SerializeField] private Transform firePosition;
    private InputManager _input;
    void Start()
    {
        _input = InputManager.Instance;
        _input.FireAction.performed += Shoot;
        _input.FireAction.canceled += OnTriggerReleased;
    }
    void Update()
    {
        
    }

    

    private void OnTriggerReleased(InputAction.CallbackContext obj)
    {
        
    }

    private void Shoot(InputAction.CallbackContext obj)
    {
        RaycastHit hit;
        float maxDistance = _stats.lazerRange;
        Vector3 origin = firePosition.position;
        Vector3 dir = firePosition.TransformDirection(Vector3.forward);
        if (Physics.Raycast(origin, dir, out hit, maxDistance))
        {
            Debug.Log(hit.transform.name);
            Destroy(hit.collider.gameObject);
        }
    }
}
