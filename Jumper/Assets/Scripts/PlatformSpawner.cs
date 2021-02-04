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

    private ScreenManager screen;
    private Vector2 spawnPlatformPosition;
    private Vector2 screenBoundsX;
    private int distanceToSpawn = 5;

    private void Awake()
    {
        screen = GetComponent<ScreenManager>();
    }

    private void Start()
    {
        screenBoundsX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Camera.main.transform.position.y, Camera.main.transform.position.z));
        spawnPlatformPosition = firstPlatform.transform.position;
    }

    private void Update()
    {
        float distanceToThePlatform = Vector2.Distance(player.transform.position, spawnPlatformPosition);

        Debug.Log(distanceToThePlatform);

        if (distanceToThePlatform < distanceToSpawn + 2)
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
        return Random.Range(screenBoundsX.x, -screenBoundsX.x);
    }
}
