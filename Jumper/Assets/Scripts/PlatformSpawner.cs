using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject player;
    public GameObject firstPlatform;
    public GameObject platformPrefab;
    public GameObject boostPlatformPrefab;

    private Vector2 spawnPlatformPosition;
    private float levelWidth = 2.3f;
    private int distanceToSpawn = 5;

    private void Start()
    {
        spawnPlatformPosition = firstPlatform.transform.position;
    }

    private void Update()
    {
        float distanceToTheTop = Vector2.Distance(player.transform.position, spawnPlatformPosition);

        if (distanceToTheTop < distanceToSpawn)
        {
            SpawnPlatforms();
        }
    }

    public void SpawnPlatforms()
    {
        //set a place to instantiate the platforms
        spawnPlatformPosition = new Vector2(0, spawnPlatformPosition.y + 1f);
        spawnPlatformPosition.x = Random.Range(- levelWidth, levelWidth);

        if (player.transform.position.y % 50f == 0)
        {
            Instantiate(boostPlatformPrefab, spawnPlatformPosition, Quaternion.identity);
        }
        else
        {
            Instantiate(platformPrefab, spawnPlatformPosition, Quaternion.identity);
        }
    }
}
