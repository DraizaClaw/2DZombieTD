using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [Header("Refrences")]
    [SerializeField] private GameObject[] enemyPrefabs;

    [Header("Attributes")]
    [SerializeField] private int baseEnemies = 8;
    [SerializeField] private float EnemiesPerSecond = .5f;
    [SerializeField] private float TimeBetweenWaves = 5f;
    [SerializeField] private float DificultyScalingFactor = 0.75f;

    private int currentWave = 1;
    private float timeSinceLastSpawn;
    private int EnemiesAlive;
    private int EnemiesLeftToSpawn;
    private bool isSpawning = false;


    public static UnityEvent onEnemyDestroy = new UnityEvent();

    private void Awake()
    {
        onEnemyDestroy.AddListener(EnemyDestroyed);
    }

    private void Start()
    {
        StartCoroutine(StartWave());
    }

    private void Update()
    {
        if (!isSpawning) return;
        
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= 1 / EnemiesPerSecond && EnemiesLeftToSpawn > 0)
        {
            SpawnEnemy();
            EnemiesLeftToSpawn--;
            EnemiesAlive++;
            timeSinceLastSpawn = 0;
        }

        if (EnemiesAlive == 0 && EnemiesLeftToSpawn == 0)
        {
            EndWave();
        }
    }


    private void EndWave()
    {
        isSpawning = false;
        timeSinceLastSpawn = 0;
        currentWave++;
        StartCoroutine(StartWave());
    }


    private void EnemyDestroyed()
    {
        EnemiesAlive--;
    }
    //what happens if an enemy is destroyed

    private void SpawnEnemy()
    {
        GameObject prefabToSpawn = enemyPrefabs[0];
        Instantiate(prefabToSpawn, LevelManager.main.StartPoint.position, Quaternion.identity);
    }
    //spawns enemies and chooses which enemies to spawn (can be randomized or set)

    private IEnumerator StartWave()
    {
        yield return new WaitForSeconds(TimeBetweenWaves);
        isSpawning = true;
        EnemiesLeftToSpawn = EnemiesPerWave();
    }
    private int EnemiesPerWave() 
    {
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, DificultyScalingFactor));
    }
    // 8 * current round ^ .75




}
