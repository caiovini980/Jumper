using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoostUp : MonoBehaviour
{
    private Rigidbody2D playerRb;

    [SerializeField] private bool canJump;
    private Animator animator;
    private float speed = 5f;

    //Animations
    private string PLAYER_JUMP = "isJumping";
    private string PLAYER_TAKEOFF = "takeOff";

    public int jumpCount;

    private void Awake()
    {
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        playerRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        jumpCount = 0;
        if (!playerRb)
            return;

        canJump = false;
    }

    private void Update()
    {
        if (canJump && playerRb.velocity.y <= 0)
        {
            animator.SetTrigger(PLAYER_TAKEOFF);
            playerRb.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
            jumpCount++;
            canJump = false;
        }
        animator.SetBool(PLAYER_JUMP, false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
        animator.SetBool(PLAYER_JUMP, true);
        Debug.Log("Collision detected");
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        animator.SetBool(PLAYER_JUMP, false);
    }

}
