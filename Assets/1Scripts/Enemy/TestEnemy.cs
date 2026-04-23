using UnityEngine;
using Random = UnityEngine.Random;
public class TestEnemy : MonoBehaviour
{
    [SerializeField] private EnemyStats stats;
    [SerializeField] private Transform firePosition;
    private Transform _target;
    private Vector3 _movePoint;
    private bool _movePointSet;
    private bool _agroPlayer;
    private float _weaponCharge;
    private float _weaponChargeNeeded;
    private int damage;
    
    
    private void Awake()
    {
        damage = stats.weaponDamage;
        _target = GameObject.Find("Player").transform;
        _weaponCharge = stats.weaponCharge;
        _weaponChargeNeeded = stats.weaponChargeNeeded;
    }

    void Start()
    {
        _agroPlayer = false;
        _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    
    void PlayerInSight()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.SphereCast(ray, stats.sightRadius, out hit, stats.sightDistance))
        {
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("Player Spotted");
                    _agroPlayer = true;
            }
        }
    }
    
    void Update()
    {
        Vector3 distanceTarget = _target.position - transform.position;
        
        if (_agroPlayer == false  && distanceTarget.magnitude > stats.agroDistance)
        {
            //look for Player
            PlayerInSight();
            Searching();
        }
        else if (_agroPlayer == true  && distanceTarget.magnitude > stats.attackDistance)
        {
            //Follow Player
            ChasePlayer();
        }
        else if (_agroPlayer == true && distanceTarget.magnitude <= stats.attackDistance)
        {
            //Attack
            Weapon();
        }
    }

    private void Searching()
    {
        if (_movePointSet == false)
        {
            SearchPoint();
        } else if (_movePointSet == true)
        {
            
            Vector3 distance = transform.position - _movePoint;
            //Move to Point
            transform.position = Vector3.MoveTowards(transform.position, _movePoint, stats.moveSpeed * Time.deltaTime);
            
            //Look Towards Point
            Vector3 direction = (_movePoint - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                lookRotation, 
                stats.turnSpeed * Time.deltaTime
            );
            if (distance.magnitude < 2)
            {
                _movePointSet = false;
            }
        }
    }
    
    private void ChasePlayer()
    {
        Vector3 direction = (_target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            lookRotation,
            stats.turnSpeed * Time.deltaTime
        );
        transform.Translate(Vector3.forward * (stats.moveSpeed * Time.deltaTime));
    }
    
    private void SearchPoint()
    {
        
        if (Random.value < stats.moveToPlayerBias)
        {
            Vector3 playerDirection = (_target.position - transform.position).normalized;
            float distanceToPlayer = Random.Range(5f, stats.searchRange);
            _movePoint = transform.position + playerDirection * distanceToPlayer;
        }
        else
        {
             float randomX = Random.Range(-stats.searchRange, stats.searchRange); 
             float randomZ = Random.Range(-stats.searchRange, stats.searchRange);
             _movePoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        }
        _movePointSet = true;
    }

    private void SearchPoint2()
    {
        Vector3 randomDirection;
                 do
                 {
                     randomDirection = new Vector3(
                                     Random.Range(-1f, 1f),
                                     0,
                                     Random.Range(-1f, 1f)
                                     ).normalized;
                                 
                                 
                 } while (Vector3.Dot(transform.forward, randomDirection) < stats.minDot);
                 float distance = Random.Range(5f, stats.searchRange);
                 _movePoint = transform.position + randomDirection * distance;
       
    }

    private void Weapon()
    {
         _weaponCharge += Time.deltaTime;
         RaycastHit hit;
         float maxDistance = stats.lazerRange;
         Vector3 origin = firePosition.position;
         Vector3 dir = firePosition.TransformDirection(Vector3.forward);
         if (_weaponCharge >= _weaponChargeNeeded)
         {
             if (Physics.SphereCast(origin,.3f, dir, out hit, maxDistance))
             {
                 Debug.Log("Lazer Fired");
                 IDamageable damageable = hit.collider.GetComponent<IDamageable>();
                 if (damageable != null)
                 {
                     damageable.TakeDamage(damage);
                     Debug.Log("Player took Damage");
                 }
             }
             _weaponCharge = 0;
         }
    }
    public void OnDestroy()
    {
        
        if (ScoreCount.Instance != null) {
            ScoreCount.Instance.AddScore(stats.pointsAmount);
        }
    }
}