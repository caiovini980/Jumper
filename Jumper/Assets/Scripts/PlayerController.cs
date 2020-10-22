using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.5f;
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
        else if (transform.position.y < -5.0f)
        {
            transform.position = new Vector2(0f, 0f);
        }
    }

    private void FixedUpdate()
    {
        if(Input.touchCount > 0)
        {
            if (Input.GetTouch(0).position.x > Screen.width / 2)
            {
                rb.AddForce(new Vector2(1 * speed * Time.deltaTime, 0));
            }
            else if (Input.GetTouch(0).position.x < Screen.width / 2)
            {
                rb.AddForce(new Vector2(-1 * speed * Time.deltaTime, 0));
            }
        }
    }
}
