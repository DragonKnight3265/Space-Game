using UnityEngine;
using Random = UnityEngine.Random;
public class BasicEnemy : MonoBehaviour
{
    [SerializeField] private EnemyStats stats;
    [SerializeField] private float agroDistance;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float turnSpeed;
    
    [SerializeField] private float searchRange;
    //Search for Player
    [SerializeField] private float sightRadius;
    [SerializeField] private float sightDistance;
    
    //How close until they start attacking
    [SerializeField] private float attackDistance;
    //How far away player can get before they get back moving to player
    [SerializeField] private float maxAttackDistance;
    [SerializeField] private float moveToPlayerBias;
    
    private Transform _target;
    public int pointsAmount = 50;
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
        if (Physics.SphereCast(ray, sightRadius, out hit, sightDistance))
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
         
        
        
        if (_agroPlayer == false  && distanceTarget.magnitude > agroDistance)
        {
            PlayerInSight();
            Searching();
        }
        else if (_agroPlayer == true  && distanceTarget.magnitude > attackDistance)
        {
            ChasePlayer();
        }
        else if (_agroPlayer == true && distanceTarget.magnitude <= attackDistance)
        {
            
        }
        
        
        
        
    }

    public void Searching()
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
                turnSpeed * Time.deltaTime
            );

            if (distance.magnitude < 2)
            {
                _movePointSet = false;
            }
        }
    }
    
    
    public void ChasePlayer()
    {
        Vector3 direction = (_target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            lookRotation,
            turnSpeed * Time.deltaTime
        );
        transform.Translate(Vector3.forward * (moveSpeed * Time.deltaTime));
    }


    private void SearchPoint()
    {

        if (Random.value < moveToPlayerBias)
        {
            Vector3 playerDirection = (_target.position - transform.position).normalized;
            float distanceToPlayer = Random.Range(5f, searchRange);
            
            _movePoint = transform.position + playerDirection * distanceToPlayer;
        }
        else
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
            float distance = Random.Range(5f, searchRange);
            _movePoint = transform.position + randomDirection * distance;
            
        }
        _movePointSet = true;
        
    }

    private void SearchPoint2()
    {
        float randomX = Random.Range(-searchRange, searchRange); 
        float randomZ = Random.Range(-searchRange, searchRange);
        _movePoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
    }
    
    
    public void OnDestroy()
    {
        if (ScoreCount.Instance != null) {
            ScoreCount.Instance.AddScore(pointsAmount);
        }
        Debug.Log("Add Points");
    }
    
    
    
    
}
