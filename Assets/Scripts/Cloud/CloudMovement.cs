using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    public float burnRateMultiplier=1;
    [SerializeField]
    float baseBurnRate=10;
    float energy=100;
    [SerializeField]
    [Range(0f, 1f)]
    float zeroEnergyMoveSpeed;
    Rigidbody2D rb2D;
    [SerializeField]
    float horizontalMovement;
    [SerializeField]
    float verticalMovement;

    [SerializeField]
    GameObject trailObject;

    private void Awake() {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        trailObject.SetActive(rb2D.velocity.magnitude > 0.2f);


        if (energy > 0) {
            rb2D.AddForce(Vector2.right * horizontalMovement * h);
            rb2D.AddForce(Vector2.up * verticalMovement * v);
            if (Mathf.Abs(h) > 0||Mathf.Abs(v)>0)
                energy -= Time.deltaTime * baseBurnRate * burnRateMultiplier;
        }
        else {
            bool jump = Input.GetButtonDown("Jump");
            rb2D.AddForce(Vector2.right * horizontalMovement * h* zeroEnergyMoveSpeed);
            if(jump)
                rb2D.AddForce(Vector2.up * verticalMovement * zeroEnergyMoveSpeed);
        }
    }
}
