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
    float randomX;
    float randomY;

    void Start()
    {
        randomX = Random.Range(-0.2f, 0.2f);
        randomY = Random.Range(-0.2f, 0.2f);
        transform.localPosition = new Vector3(randomX*0.1f, randomY*0.1f); 
        transform.localScale+= new Vector3(randomX, randomY);
        initialPosition = transform.localPosition;
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
