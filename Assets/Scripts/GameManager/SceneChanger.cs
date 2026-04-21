using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public SceneChanger Instance;
    public bool defeated = false;
    public bool victorious = false;
    
    public int sceneBuildIndexStart = 0;
    public int sceneBuildIndexDefeat = 2;
    public int sceneBuildIndexVictorious;

    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    
    void Start()
    {
        
    }
    
    void Update()
    {
        
        
        if (defeated == true)
        {
            SceneManager.LoadScene(sceneBuildIndexDefeat);
        }
        else if (victorious == true)
        {
            
        }
    }
}
