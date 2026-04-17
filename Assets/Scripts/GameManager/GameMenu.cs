using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private int gameScene;

    public void Play()
    {
        SceneManager.LoadScene(gameScene);
    }

    public void Options()
    {
        
    }
    
    public void Quit()
    {
        Application.Quit();
    }
}
