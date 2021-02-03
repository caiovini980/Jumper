using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.5f;
    private bool isTouched;
    private bool _isMovingLeft = false;
    private bool _isMovingRight = false;
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

        CalculateMovement();
    }

    public void CalculateMovement()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                isTouched = true;
            }

            else if (touch.phase == TouchPhase.Stationary)
            {
                if (isTouched)
                {
                    if (touch.position.x > Screen.width / 2)
                    {
                        //go right
                        MoveRight();
                    }

                    else if (touch.position.x < Screen.width / 2)
                    {
                        //go left
                        MoveLeft();
                    }
                }
            }

            else if (touch.phase == TouchPhase.Ended)
            {
                StopMoving();
            }
        }
    }

    void MoveRight()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
        _isMovingRight = true;
    }

    void MoveLeft()
    {
        rb.velocity = new Vector2(-speed, rb.velocity.y);
        _isMovingLeft = true;
    }

    void StopMoving()
    {
        rb.velocity = new Vector2(0f, rb.velocity.y);
        _isMovingRight = false;
        _isMovingLeft = false;
    }
}