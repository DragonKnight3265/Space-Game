using UnityEngine;
using UnityEngine.InputSystem;

public class MissileLocking : MonoBehaviour
{
    
    private InputManager _input;
    
    [SerializeField] private ShipStats _stats;
    [SerializeField] private float lockRadius;
    [SerializeField] private Transform spawnLocation;
    
    public LayerMask targetLayer;
    public GameObject missilePrefab;
    private Transform currentTarget;
    private bool _lockComplete;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _input = InputManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (_input.MissileDown && !_lockComplete)
        {
            AttemptLockTarget();
        }
        
        

        if (_lockComplete && _input.MissileLaunch)
        {
            FireMissile();
            ResetLock();
        }

        if (!_input.MissileDown && !_lockComplete)
        {
            ResetLock();
        }
        
    }

    void AttemptLockTarget()
    {
        if (currentTarget == null)
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.SphereCast(ray,lockRadius , out hit, _stats.missileRange, targetLayer))
            {
                if (hit.collider.CompareTag("LockableTarget"))
                {
                    currentTarget = hit.collider.transform;
                }
                Debug.Log(hit.collider.gameObject.name + " locking");
            }
        }
        if (currentTarget != null)
        {
            _stats.lockTime += Time.deltaTime;

            if (_stats.lockTime >= _stats.lockTimeNeeded)
            {
                _stats.lockTime = _stats.lockTimeNeeded;
                _lockComplete = true;
                Debug.Log("Lock Complete");
            }
        }
    }
    
    
    void FireMissile()
        {
            GameObject missile = Instantiate(missilePrefab, spawnLocation.position, spawnLocation.rotation);
            missile.GetComponent<Missile>().SetTarget(currentTarget);
       }     

    void ResetLock()
    {
        _stats.lockTime = 0;
        currentTarget = null;
        _lockComplete = false;
    }
    
}
