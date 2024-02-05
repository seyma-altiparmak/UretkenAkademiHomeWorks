using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLikeButton : MonoBehaviour
{
    public GameObject likeButtonPrefab;
    public float spawnInterval = 2f;
    float spawnRangeX;
    float spawnRangeY;
    float spawnRangeZ;

    private float nextSpawnTime = 0f;

    private void Awake()
    {
        spawnRangeX = transform.position.x;
        spawnRangeZ = transform.position.z;
        spawnRangeY = transform.position.y;
    }
    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnLikeButton();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnLikeButton()
    {
        float randomRotationY = Random.Range(0f, 10f);
        Quaternion randomRotation = Quaternion.Euler(0f, randomRotationY, 0f);

        // Instantiate the like button prefab at the random position
        Vector3 spawnPosition = new Vector3(spawnRangeX, spawnRangeY, spawnRangeZ);
        Instantiate(likeButtonPrefab, spawnPosition, randomRotation);
        MoneyController.money += 2;
    }
}
