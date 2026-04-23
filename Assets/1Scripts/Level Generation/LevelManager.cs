using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class LevelManager : MonoBehaviour
{
    public Transition transition;
    
    public bool movingLevels = false;
    
    public static LevelManager instance;
    public int currentLevel = 1;
    [SerializeField] public int enemiesPerLevel = 3;
    [SerializeField] public float spawnRadius = 60f;
    [SerializeField] public float minDistanceFromPlayer = 35f;
    
    public GameObject player;
    [Header("Enemey types")]
    [SerializeField] public GameObject easyEnemiesPrefab;
    [SerializeField] public GameObject mediumEnemiesPrefab;
    [SerializeField] public GameObject hardEnemiesPrefab;

    [Header("Enemy Scaling")] 
    [SerializeField] public float strongEnemyChance = 0f;
    [SerializeField] public float hardEnemyChance = 0f;
    [SerializeField] public float chanceIncrease = .05f;
    [SerializeField] public int levelsPerIncrease = 3;
    [SerializeField] public float maxStrongEnemyChance = .75f;
    [SerializeField] public float maxHardEnemyChance = .40f;
    
    public int enemiesAlive = 0;
    
    
    public void Awake()
    {
        instance = this;
    }

    
    void Start()
    {
        StartLevel();
    }
    
    void StartLevel()
    {
        strongEnemyChance = Mathf.Min(
            (currentLevel/levelsPerIncrease) * chanceIncrease, 
            maxStrongEnemyChance
            );
        int enemyCount = enemiesPerLevel + (currentLevel/4)*2;
        enemiesAlive = enemyCount;
        for (int i = 0; i < enemyCount; i++)
        {
            SpawnEnemies();
        }
        StartCoroutine(transition.FadeOut());
        
    }

    void SpawnEnemies()
    {
        Vector3 spawnPos = GetValidSpawnPostion();
        
        GameObject enemyToSpawn;
        
        if (Random.value < strongEnemyChance)
        {
            enemyToSpawn = mediumEnemiesPrefab;
        }
        else
        {
            enemyToSpawn = easyEnemiesPrefab;
        }
        Instantiate(enemyToSpawn, spawnPos, Quaternion.identity);
    }

    Vector3 GetValidSpawnPostion()
    {
        Vector3 pos;
        do
        {
            Vector2 randomCircle = Random.insideUnitCircle * spawnRadius;
            pos = new Vector3(randomCircle.x, 0, randomCircle.y) + player.transform.position;
            
        } while (Vector3.Distance(pos, player.transform.position) < minDistanceFromPlayer);
        return pos;
    }

    public void EnemyKilled()
    {
        enemiesAlive--;
        if (enemiesAlive <= 0)
        {
            StartCoroutine(NextLevel());
        }
    }

    IEnumerator NextLevel()
    {
        movingLevels = true;
        yield return new WaitForSeconds(1f);
        yield return StartCoroutine(transition.FadeIn());
        currentLevel++;
        StartLevel();
        yield return StartCoroutine(transition.FadeOut());
        yield return new WaitForSeconds(1f);
        movingLevels = false;
    }
    
    
}
