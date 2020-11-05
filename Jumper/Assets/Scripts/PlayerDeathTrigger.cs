using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathTrigger : MonoBehaviour
{
    private string playerTag = "Foot";
    public Transform cameraTransform;
    private GameObject player;
    private Rigidbody2D playerRb;
    private SpriteRenderer playerSprite;
    public bool isPlayerDead = false;

    private void Awake()
    {
        player = GameObject.Find("Player");
        playerRb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        playerSprite = GameObject.Find("Player").GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        transform.position = new Vector3(cameraTransform.position.x, cameraTransform.position.y - 6f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {
            //destroy player
            //play death particles
            playerRb.constraints = RigidbodyConstraints2D.FreezeAll;
            playerSprite.enabled = false;
            Debug.Log("COLIDIU PORRA");
            Destroy(player, 2f);
            isPlayerDead = true;
        }
    }
}
