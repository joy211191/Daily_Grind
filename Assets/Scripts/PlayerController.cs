using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float playerSpeed;
    Rigidbody2D rb2D;
    Animator anim;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetKey(KeyCode.Space))
        {
            rb2D.velocity = new Vector2(Input.GetAxis("Horizontal") * playerSpeed, Input.GetAxis("Vertical") * playerSpeed);
            Vector2 inputVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            if (inputVector.magnitude > 0)
            {
                anim.Play("Walk");
                transform.up = rb2D.velocity;
            }
            else
                anim.Play("");
        }
        else
        {
            anim.Play("Chop");
            rb2D.velocity = Vector2.zero;
        }
    }
}