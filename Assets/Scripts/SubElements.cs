using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubElements : MonoBehaviour
{
    public float shakeDuration;
    Vector2 initialPosition;
    [SerializeField]
    float dampening;
    [SerializeField]
    float shakeMagnitude;

    void Start()
    {
        initialPosition = transform.position;
    }

    public void Shake()
    {
        shakeDuration = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (shakeDuration > 0)
        {
            transform.localPosition = initialPosition + Random.insideUnitCircle * shakeMagnitude;
            shakeDuration -= Time.deltaTime * dampening;
        }
        else
        {
            shakeDuration = 0f;
            transform.localPosition = initialPosition;
        }
    }
}
