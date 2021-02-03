using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoostUp : MonoBehaviour
{
    private Rigidbody2D playerRb;
    [SerializeField] bool canJump;
    private Animator animator;

    public float jumpSpeed = 10f;

    private void Awake()
    {
        animator = GetComponentInParent<Animator>();
        playerRb = GetComponentInParent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!playerRb)
            return;
    }

    private void Update()
    {
        if (canJump)
        {
            Vector2 velocity = playerRb.velocity;
            velocity.y = jumpSpeed;
            playerRb.velocity = velocity;

            canJump = false;
        }

        jumpSpeed = 10f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y >= 0f)
        {
            canJump = true;

            if (collision.transform.CompareTag("BoostPlatform"))
            {
                jumpSpeed = 30f;
            }

            if (collision.gameObject.CompareTag("BreakablePlatform"))
            {
                Debug.Log("fala bolo");
                Destroy(collision.gameObject, 0.1f);
            }
        }
    }
}
