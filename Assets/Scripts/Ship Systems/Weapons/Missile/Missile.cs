using UnityEngine;
using UnityEngine.InputSystem;

public class Missile : MonoBehaviour
{
    private InputManager _input;
    
    
    private Transform _target;
    private bool _hadTarget = false;
    [SerializeField] private float hitDistance;
    [SerializeField] private ShipStats stats;
    [SerializeField] private Transform firePosition;
    void Start()
    {
        _input = InputManager.Instance;
    }
    
    void Update()
    {
        
        
        if (_target == null)
        {
            if (_hadTarget)
            {
                Destroy(gameObject);
            }
            return;
        }
        
        
        Vector3 direction = (_target.position - transform.position).normalized;
        float distance = Vector3.Distance(transform.position, _target.position);
        
        if (distance < hitDistance)
        {
             transform.position = Vector3.MoveTowards(
                 transform.position,
                 _target.position,
                 Time.deltaTime*stats.missileSpeed);
        }
        else
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(
                        transform.rotation,
                        lookRotation,
                        stats.missileTurnSpeed * Time.deltaTime
                    );
                    transform.Translate(Vector3.forward * (stats.missileSpeed * Time.deltaTime));
        }
        
        
    }

    
    

    public void SetTarget(Transform newtarget)
    {
        _target = newtarget;
    }
    
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.collider.name.Equals(_target.name))
        {
            Debug.Log("Target hit!");
            Destroy(collision.gameObject);
            Destroy(gameObject);
            
        }
    }
}