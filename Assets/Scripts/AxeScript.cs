using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Tree")
        {
            collision.gameObject.GetComponent<TreeShake>().ShakeTree();
        }
    }
}
