using System.Collections.Generic;
using UnityEngine;

public class PipeGenerator : MonoBehaviour
{
    public PipePlayerController playerController;
    public GameObject pipeSegmentPrefab;

    public int segmentsAhead = 12; 
    public float segmentLength = 10f;

    private float spawnZ = 0f;
    private Queue<GameObject> segments = new Queue<GameObject>();

    void Start()
    {
        for (int i = 0; i < segmentsAhead; i++)
        {
            SpawnSegment();
        }

        UpdatePlayerPipe();
    }

    void Update()
    {
        if (playerController.pipeCenter == null) return;

        float playerZ = playerController.GetForwardOffset();

        if (playerZ + (segmentsAhead * segmentLength / 2f) > spawnZ)
        {
            SpawnSegment();
            RemoveOld();
            UpdatePlayerPipe();
        }
    }

    void SpawnSegment()
    {
        GameObject seg = Instantiate(pipeSegmentPrefab, new Vector3(0, 0, spawnZ), Quaternion.identity);
        segments.Enqueue(seg);
        spawnZ += segmentLength;
    }

    void RemoveOld()
    {
        while (segments.Count > segmentsAhead)
        {
            Destroy(segments.Dequeue());
        }
    }

    void UpdatePlayerPipe()
    {
        GameObject closest = null;
        float minDist = Mathf.Infinity;

        foreach (var seg in segments)
        {
            float dist = Mathf.Abs(playerController.GetForwardOffset() - seg.transform.position.z);
            if (dist < minDist)
            {
                minDist = dist;
                closest = seg;
            }
        }

        if (closest != null)
        {
            Transform center = closest.transform.Find("CenterPoint");
            if (center != null)
                playerController.pipeCenter = center;
        }
    }
}