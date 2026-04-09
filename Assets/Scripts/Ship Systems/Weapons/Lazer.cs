using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class Lazer : MonoBehaviour
{
    [SerializeField]private ShipStats stats;
    [SerializeField] private Camera shootPosition;
    [SerializeField] private Transform firePosition;
    
    private InputManager _input;
    private int damage;

    private float _weaponCharge;
    private float _weaponChargeNeeded;
    private void Awake()
    {
        damage = stats.weaponDamage;
        _weaponCharge = stats.weaponCharge;
        _weaponChargeNeeded = stats.weaponChargeNeeded;
    }

    void Start()
    {
        _input = InputManager.Instance;
        _input.FireAction.performed += Shoot;
        
    }
    void Update()
    {
        _weaponCharge += Time.deltaTime;
    }
    
    private void Shoot(InputAction.CallbackContext obj)
    {
        RaycastHit hit;
        float maxDistance = stats.lazerRange;
        Vector3 origin = firePosition.position;
        Vector3 dir = firePosition.TransformDirection(Vector3.forward);
        if(_weaponCharge>=_weaponChargeNeeded) 
            if (Physics.SphereCast(origin,.5f, dir, out hit, maxDistance))
        {
            IDamageable damageable = hit.collider.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(damage);
            }
            _weaponCharge = 0;
        }
    }
}
