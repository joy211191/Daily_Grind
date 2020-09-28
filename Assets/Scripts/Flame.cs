using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{
    Vector2 initialPosition;
    [SerializeField]
    float dampening;
    [SerializeField]
    float shakeMagnitude;

    private void Awake()
    {
        initialPosition = transform.localPosition;
    }

    private void Update()
    {
        transform.localPosition = initialPosition + Random.insideUnitCircle * shakeMagnitude;
    }
}
