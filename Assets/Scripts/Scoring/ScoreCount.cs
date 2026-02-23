using TMPro;
using UnityEngine;

public class ScoreCount : MonoBehaviour
{
    [SerializeField] public TMP_Text scoreText;
    public static ScoreCount Instance;
    private int score;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance  = this;
        }
    }
    
    void Start()
    {
        score = 0;
        UpdateScoreText();
    }
    
public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }


    void UpdateScoreText()
    {
        scoreText.text = "Score:" + score.ToString();
    }
    void Update()
    {
        UpdateScoreText();
    }
    
    
    
}
