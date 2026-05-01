using UnityEngine;
using UnityEngine.UI;

using Random = UnityEngine.Random;
public class MissileLocking : MonoBehaviour
{
    
    private InputManager _input;
    
    [SerializeField] private ShipStats _stats;
    [SerializeField] private float lockRadius;
    [SerializeField] private Transform spawnLocation;
    [SerializeField] private Image crossHairImage;
    
    public LayerMask targetLayer;
    public GameObject missilePrefab;
    private Transform currentTarget;
    private bool _lockComplete;
    public int missileAmmo;
    private int maxMissiles;
    
    
    void Start()
    {
        _input = InputManager.Instance;
        _stats.missileAmmo=_stats.maxMissiles;
        maxMissiles = _stats.maxMissiles;
        missileAmmo = _stats.missileAmmo;
    }
    
    void Update()
    {
        if (_input.MissileDown && !_lockComplete)
        {
            if (missileAmmo > 0)
            {
                AttemptLockTarget();
            }
            else
            {
                Debug.Log("No Missiles Left");
            }
            
        }
        
        if (_lockComplete && _input.MissileLaunch && missileAmmo>=1)
        {
            FireMissile();
            ResetLock();
            missileAmmo-=1;
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
                crossHairImage.color = Color.green;
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
        crossHairImage.color = Color.white;
    }

    public void MissileReload()
    {
        missileAmmo += Random.Range(1, 4);
        missileAmmo = Mathf.Min(missileAmmo, maxMissiles);
        Debug.Log("Missile Reload");
    }
    
}
