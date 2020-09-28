using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float playerSpeed;
    Rigidbody2D rb2D;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb2D.velocity= new Vector2(Input.GetAxis("Horizontal")*playerSpeed, Input.GetAxis("Vertical")*playerSpeed);
        Vector2 inputVector= new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (inputVector.magnitude>0)
            transform.up = rb2D.velocity;
    }
}