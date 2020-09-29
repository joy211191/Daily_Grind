using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camp : MonoBehaviour
{
    public bool discovered;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player")
            discovered = true;
    }
}
