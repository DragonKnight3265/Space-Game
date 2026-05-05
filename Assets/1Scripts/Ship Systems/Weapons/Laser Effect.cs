using System;
using UnityEngine;
public class LaserEffect : MonoBehaviour
{
    public Vector3 _target;
    [SerializeField] public GameObject collisionExplosion;
    [SerializeField] public float speed;
    
    private void Update()
    {
        float step = speed * Time.deltaTime;

        if (_target != null)
        {
            if (transform.position == _target)
            {
                explode();
                return;
            }
            transform.position = Vector3.MoveTowards(transform.position, _target, step);
        }
    }


    public void setTarget(Vector3 target)
    {
        _target = target;
    }

    public void explode()
    {
        if (collisionExplosion != null)
        {
            GameObject explosion = (GameObject)Instantiate(
                collisionExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(explosion, 2f);
        }
    }
    
    
}
