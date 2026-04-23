using System;
using UnityEngine;
public class LaserEffect : MonoBehaviour
{
    [SerializeField] LineRenderer line;
    private float duration = .5f;

    private void Awake()
    {
        line = GetComponent<LineRenderer>();
    }

    public void Fire(Vector3 start, Vector3 end)
    {
        line.SetPosition(0, start);
        line.SetPosition(1, end);
        
        Invoke(nameof(DestorySelf), duration);
    }

    void DestorySelf()
    {
        Destroy(gameObject);
    }
}
