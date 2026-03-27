using TMPro;
using UnityEngine;

public class ScoreCount : MonoBehaviour
{
    [SerializeField] public TMP_Text scoreText;
    [SerializeField] public TMP_Text levelText;
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

    public void UpdateLevelText()
    {
        levelText.text = "Level:" + LevelManager.instance.currentLevel;
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
