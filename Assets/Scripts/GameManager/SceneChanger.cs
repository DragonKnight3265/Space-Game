using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    
    public bool defeated = false;
    public bool victorious = false;
    
    public int sceneBuildIndexStart;
    public int sceneBuildIndexDefeat;
    public int sceneBuildIndexVictorious;
    
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
