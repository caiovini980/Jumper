using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    private Vector3 startPosition;
    private float repeatWidth;
    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        repeatWidth = GetComponent<BoxCollider2D>().size.y / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y < startPosition.y - repeatWidth)
        {
            transform.position = startPosition;
        }
    }
}
