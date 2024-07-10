using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    #region variables
    // bg.
    [SerializeField] private Vector2 movementSpeed;
    private Vector2 offset;
    private Material material;
    // obstacles.
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] GameObject coinPrefab;
    [SerializeField] GameObject tallObstaclePrefab;
    [SerializeField] float tallObstacleChance = 0.2f;
    [SerializeField] float obstacleSpeed = 2f;
    #endregion

    private void Start()
    {
        SpawnObstacle();
        SpawnCoins();
    }

    void SpawnObstacle()
    {
        GameObject obstacleToSpawn = obstaclePrefab;
        float random = Random.Range(0f, 1f);
        if (random < tallObstacleChance)
        {
            obstacleToSpawn = tallObstaclePrefab;
        }

        int obstacleSpawnIndex = Random.Range(0, 3);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        GameObject obstacle = Instantiate(obstacleToSpawn, spawnPoint.position, Quaternion.identity, transform);
        obstacle.AddComponent<MoveLeft>().speed = obstacleSpeed;
    }

    void SpawnCoins()
    {
        //Añadir para que el player vaya aumentando velocidad
        int coinsToSpawn = 10;

        for (int i = 0; i < coinsToSpawn; i++)
        {
            GameObject temp = Instantiate(coinPrefab, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider2D>());
            temp.AddComponent<MoveLeft>().speed = obstacleSpeed;
        }
    }

    Vector2 GetRandomPointInCollider(Collider2D collider)
    {
        Vector2 point = new Vector2
            (
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y)
            );

        if (point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }

        return point;
    }

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    private void Update()
    {
        offset = movementSpeed * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
