using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPass : MonoBehaviour
{
    private Collider2D foot;

    private void Awake()
    {
        foot = GameObject.FindGameObjectWithTag("Foot").GetComponent<Collider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!foot)
            return;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("TopPlatform"))
        {
            foot.enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("TopPlatform"))
        {
            StartCoroutine(WaitToJump(0.2f));
            foot.enabled = true;
        }
    }

    IEnumerator WaitToJump(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }
}
