using TMPro;
using UnityEngine;

public class ScoreCount : MonoBehaviour
{
    [SerializeField] public TMP_Text scoreText;
    [SerializeField] public TMP_Text levelText;
    public static ScoreCount Instance;
    private int score;
    private int level;
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
        level = 0 + LevelManager.instance.currentLevel;
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

    public void UpdateLevelText()
    {
        
        levelText.text = "Level:" + level;
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score:" + score.ToString();
    }
    void Update()
    {
        UpdateScoreText();
        UpdateLevelText();
    }
    
    
    
}
