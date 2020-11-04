﻿using System.Collections;
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

    [SerializeField]
    float maxSpeed;

    CloudCharges cloudCharges;
    SpriteRenderer spriteRenderer;

    private void Awake() {
        rb2D = GetComponent<Rigidbody2D>();
        cloudCharges = GetComponent<CloudCharges>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate() {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        burnRateMultiplier = cloudCharges.EffectiveBoostValue();
        spriteRenderer.color = cloudCharges.ColorCheck();
        if (rb2D.velocity.magnitude > maxSpeed)
            rb2D.velocity = maxSpeed * rb2D.velocity.normalized;
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

    private void Update() {
        float sizeTemp = energy / 100;
        sizeTemp= Mathf.Clamp(sizeTemp, 0.2f, 1);
        transform.localScale = new Vector3(sizeTemp, sizeTemp, 1);

    }

    public bool EnergyRecharge() {
        if (energy < 100) {
            energy += Time.deltaTime * baseBurnRate;
            return false;
        }
        else {
            return true;
        }

    }
}
