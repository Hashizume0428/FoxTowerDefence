using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [Header("EnemyGenerator Settings")]
    [SerializeField] private float hp;
    [SerializeField] private float maxHp;
    [SerializeField] private bool isActive = true;
    [SerializeField] private int maxEnemies = 50;
    private float spawnTimer;
    [SerializeField] private float spawnInterval = 3.0f;
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private GameObject[] spawnPoints;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnTimer = spawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0f)
        {
            SpawnEnemy();
            spawnTimer = spawnInterval; // Reset the spawn timer
        }
    }
    void SpawnEnemy()
    {
        if (!isActive) return;

        int currentEnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (currentEnemyCount >= maxEnemies) return;

        int randomEnemyIndex = Random.Range(0, enemyPrefabs.Length);
        int randomSpawnPointIndex = Random.Range(0, spawnPoints.Length);

        Instantiate(enemyPrefabs[randomEnemyIndex], spawnPoints[randomSpawnPointIndex].transform.position, Quaternion.identity);
    }
}
