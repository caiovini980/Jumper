using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.5f;
    private float movementX = 0f;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!rb)
            return;
    }

    private void Update()
    {
        if (transform.position.x > 3.0f)
        {
            transform.position = new Vector2(-3f, transform.position.y);
        }
        else if (transform.position.x < -3.0f)
        {
            transform.position = new Vector2(3f, transform.position.y);
        }

        CalculateMovement(); //PC Only
    }

    public void CalculateMovement()
    {
        movementX = Input.GetAxis("Horizontal") * speed;
    }

    private void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = movementX;
        rb.velocity = velocity;

        /*if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).position.x > Screen.width / 2)
            {
                //go right
            }
            else if (Input.GetTouch(0).position.x < Screen.width / 2)
            {
                //go left
            }
        }*/
    }
}