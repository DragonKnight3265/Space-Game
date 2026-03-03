using UnityEngine;
using UnityEngine.InputSystem;

public class Lazer : MonoBehaviour
{
    [SerializeField]private ShipStats stats;
    [SerializeField] private Camera shootPosition;
    [SerializeField] private Transform firePosition;
    private InputManager _input;
    private float _weaponCharge;
    private float _weaponChargeNeeded;
    void Awake()
    {
        _weaponCharge = stats.weaponCharge;
        _weaponChargeNeeded = stats.weaponCharge;
    }
    void Start()
    {
        _input = InputManager.Instance;
        _input.FireAction.performed += Shoot;
        _input.FireAction.canceled += OnTriggerReleased;
    }
    void Update()
    {
        _weaponCharge += Time.deltaTime;
    }

    

    private void OnTriggerReleased(InputAction.CallbackContext obj)
    {
        
    }

    private void Shoot(InputAction.CallbackContext obj)
    {
        RaycastHit hit;
        float maxDistance = stats.lazerRange;
        Vector3 origin = firePosition.position;
        Vector3 dir = firePosition.TransformDirection(Vector3.forward);
        if (Physics.Raycast(origin, dir, out hit, maxDistance) && _weaponCharge >= _weaponChargeNeeded)
        {
            IDamageable damageable = hit.collider.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(stats.weaponDamage);
                Debug.Log("Enemy took damage");
            }
        }
        _weaponCharge = 0;
    }
}
