using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    Rigidbody2D rb2D;
    [SerializeField]
    float sideMovementForce;
    [SerializeField]
    float jumpForce;

    private void Awake() {
        rb2D = GetComponent<Rigidbody2D>();   
    }

    private void FixedUpdate() {
        float h = Input.GetAxis("Horizontal");
        rb2D.AddForce(Vector2.right* sideMovementForce * h);

        if (Input.GetButton("Jump")) {
            rb2D.AddForce(Vector2.up * jumpForce);
        }
        
    }
}
