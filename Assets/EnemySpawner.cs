using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public PipePlayerController player;

    public float spawnDistance = 50f;
    public float radius = 2f;

    // 💥 волны
    public int wave = 1;
    public int enemiesPerWave = 5;

    private int enemiesSpawned = 0;

    // ⏱ таймер
    public float spawnInterval = 1f;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (enemiesSpawned < enemiesPerWave)
        {
            if (timer >= spawnInterval)
            {
                SpawnEnemy();
                timer = 0f;
                enemiesSpawned++;
            }
        }
        else
        {
         
            NextWave();
        }
    }

    void SpawnEnemy()
    {
        float playerZ = player.GetForwardOffset();

        float angle = Random.Range(0f, 360f);

        Vector3 offset = new Vector3(
            Mathf.Cos(angle * Mathf.Deg2Rad),
            Mathf.Sin(angle * Mathf.Deg2Rad),
            0
        ) * radius;

        Vector3 spawnPos = offset + Vector3.forward * (playerZ + spawnDistance);

        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }

    void NextWave()
    {
        wave++;

        
        enemiesPerWave += 3;       
        spawnInterval *= 0.9f;     

        
        spawnInterval = Mathf.Clamp(spawnInterval, 0.2f, 5f);

        enemiesSpawned = 0;

        Debug.Log("WAVE: " + wave + " | ENEMIES: " + enemiesPerWave);
    }
}