using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoEffect : MonoBehaviour
{
    private float timeBetweenSpawns;
    public float startTimeBetweenSpawns;

    public GameObject echo;

    private void Update()
    {
        if (timeBetweenSpawns <= 0)
        {
            //spawn echoes gameobject
            Instantiate(echo, transform.position, Quaternion.identity);
            timeBetweenSpawns = startTimeBetweenSpawns;
        }
        else
        {
            timeBetweenSpawns -= Time.deltaTime;
        }
    }
}
