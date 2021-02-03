using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    private Transform destructiblePlatform;

    private void Start()
    {
        destructiblePlatform = transform.parent.parent.parent;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Foot"))
        {
            Destroy(destructiblePlatform);
        }
    }
}
