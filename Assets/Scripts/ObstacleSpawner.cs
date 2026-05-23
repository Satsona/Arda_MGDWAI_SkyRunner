using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Obstacle")]
    [SerializeField] private GameObject obstaclePrefab;

    [Header("Spawn Settings")]
    [SerializeField] private float spawnZ = 20f;
    [SerializeField] private float obstacleY = 0.5f;
    [SerializeField] private float spawnInterval = 1.5f;

    [Header("Lanes")]
    [SerializeField] private float[] lanePositions = { -2f, 0f, 2f };

    private float spawnTimer;

    private void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.IsGameEnded()) return;

        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            spawnTimer = 0f;
            SpawnObstacle();
        }
    }

    private void SpawnObstacle()
    {
        if (obstaclePrefab == null) return;

        int randomLane = Random.Range(0, lanePositions.Length);

        Vector3 spawnPosition = new Vector3(
            lanePositions[randomLane],
            obstacleY,
            spawnZ
        );

        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
    }
}