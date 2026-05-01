using System.Timers;
using UnityEngine;

public class ExplosionDestroy : MonoBehaviour
{
    [SerializeField] private float explosionTimer;
    
    void Start()
    {
        ParticleSystem ps = GetComponent<ParticleSystem>();
        Destroy(gameObject, explosionTimer);
    }
    
}
