using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject player;
    public GameObject firstPlatform;
    public GameObject platformPrefab;
    public GameObject boostPlatformPrefab;
    public GameObject breakablePlatformPrefab;

    private Vector2 spawnPlatformPosition;
    private float levelWidth = 2.3f;
    private int distanceToSpawn = 5;

    private void Start()
    {
        spawnPlatformPosition = firstPlatform.transform.position;
    }

    private void Update()
    {
        float distanceToThePlatform = Vector2.Distance(player.transform.position, spawnPlatformPosition);

        if (distanceToThePlatform < distanceToSpawn)
        {
            SpawnPlatforms();
        }
    }

    public void SpawnPlatforms()
    {
        //set a place to instantiate the platforms
        spawnPlatformPosition = new Vector2(GetRandomPositionX(), spawnPlatformPosition.y + 1f);

        int spawnRandomPlatformIndex = GetRandomPlatform();

        //Spawn normal Platforms
        if (spawnRandomPlatformIndex <= 60)
        {
            Instantiate(platformPrefab, spawnPlatformPosition, Quaternion.identity);
        }

        //Spawn Moving Platforms
        else if (spawnRandomPlatformIndex > 60 && spawnRandomPlatformIndex <= 90)
        {
            Instantiate(breakablePlatformPrefab, spawnPlatformPosition, Quaternion.identity);
        }

        //Spawn Boost Platforms
        else if (spawnRandomPlatformIndex > 90)
        {
            Instantiate(boostPlatformPrefab, spawnPlatformPosition, Quaternion.identity);
        }
    }

    int GetRandomPlatform()
    {
        return Random.Range(1, 100);
    }

    float GetRandomPositionX()
    {
        return Random.Range(-levelWidth, levelWidth);
    }
}
