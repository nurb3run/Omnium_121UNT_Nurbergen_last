using UnityEngine;

public class RBCSpawner : MonoBehaviour
{
    public GameObject rbcPrefab;
    public PipePlayerController player;

    public float spawnInterval = 2f;

    public float radius = 2f;       // радиус трубы (как у enemy)
    public float spawnBehind = -5f; 

    public int minSwarm = 3;
    public int maxSwarm = 6;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnSwarm();
            timer = 0f;
        }
    }

    void SpawnSwarm()
    {
        float playerZ = player.GetForwardOffset();

        int count = Random.Range(minSwarm, maxSwarm + 1);

        for (int i = 0; i < count; i++)
        {
            float angle = Random.Range(0f, 360f);

            Vector3 offset = new Vector3(
                Mathf.Cos(angle * Mathf.Deg2Rad),
                Mathf.Sin(angle * Mathf.Deg2Rad),
                0
            ) * radius;

            // тут разброс
            offset += new Vector3(
                Random.Range(-0.2f, 0.2f),
                Random.Range(-0.2f, 0.2f),
                0
            );

            Vector3 spawnPos = offset + new Vector3(0, 0, playerZ + spawnBehind);

            Instantiate(rbcPrefab, spawnPos, Quaternion.identity);
        }
    }
}