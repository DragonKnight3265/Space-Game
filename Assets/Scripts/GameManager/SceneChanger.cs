using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public bool Defeated = false;
    public bool Victorious = false;
    
    public int sceneBuildIndexStart;
    public int sceneBuildIndexVictorious;
    public int sceneBuildIndexDefeat;
    
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Defeated == true)
        {
            SceneManager.LoadScene(sceneBuildIndexDefeat);
        }
        else if (Victorious == true)
        {
            
        }
    }
}
