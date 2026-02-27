using UnityEngine;
using Random = UnityEngine.Random;
public class BasicEnemy : MonoBehaviour
{
    [SerializeField] private EnemyStats stats;
    [SerializeField] private Transform firePosition;
    private Transform _target;
    private Vector3 _movePoint;
    private bool _movePointSet;
    private bool _agroPlayer;
    
    
    private void Awake()
    {
        _target = GameObject.Find("Player").transform;
    }

    void Start()
    {
        _agroPlayer = false;
        _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    
    void PlayerInSight()
    {
        //Shoot a Sphere Cast out and if they see player than Turn _agroPlayer to True
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
            PlayerInSight();
            Searching();
        }
        else if (_agroPlayer == true  && distanceTarget.magnitude > stats.attackDistance)
        {
            ChasePlayer();
        }
        else if (_agroPlayer == true && distanceTarget.magnitude <= stats.attackDistance)
        {
            if (distanceTarget.magnitude > stats.maxFireDistance)
            {
                ChasePlayer();
            }
            else
            {
                Weapon();
            }
            
            
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
         stats.weaponChargeTime += Time.deltaTime;
         if (stats.weaponChargeTime >= stats.weaponChargeNeeded)
         {
             RaycastHit hit;
             float maxDistance = stats.weaponRange;
             Vector3 origin = firePosition.position;
             Vector3 dir = firePosition.TransformDirection(Vector3.forward);
             if (Physics.Raycast(origin, dir, out hit, maxDistance))
             {
                 
             }
         }
    }
    
    public void OnDestroy()
    {
        if (ScoreCount.Instance != null) {
            ScoreCount.Instance.AddScore(stats.pointsAmount);
        }
        Debug.Log("Add Points");
    }
    
}
