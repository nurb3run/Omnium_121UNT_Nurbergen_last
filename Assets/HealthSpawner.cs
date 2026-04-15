using UnityEngine;

public class HealthSpawner : MonoBehaviour
{
    public GameObject healthPrefab;
    public PipePlayerController player;

    public float spawnDistance = 60f;
    public float radius = 2f;

    public float spawnInterval = 6f; 
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            
            if (Random.value < 0.2f)
            {
                SpawnHealth();
            }

            timer = 0f;
        }
    }

    void SpawnHealth()
    {
        float playerZ = player.GetForwardOffset();

        float angle = Random.Range(0f, 360f);

        Vector3 offset = new Vector3(
            Mathf.Cos(angle * Mathf.Deg2Rad),
            Mathf.Sin(angle * Mathf.Deg2Rad),
            0
        ) * radius;

        Vector3 spawnPos = offset + Vector3.forward * (playerZ + spawnDistance);

        Instantiate(healthPrefab, spawnPos, Quaternion.identity);

        Debug.Log("HEALTH SPAWNED");
    }
}