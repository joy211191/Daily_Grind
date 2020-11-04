using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudValue : MonoBehaviour
{
    public bool gray;
    SpriteRenderer spriteRenderer;

    [SerializeField]
    CloudValues cloudValues;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if(gray)
            spriteRenderer.color = new Color(cloudValues.lowestCloudColor, cloudValues.lowestCloudColor, cloudValues.lowestCloudColor);
        else
            spriteRenderer.color = new Color(cloudValues.highestCloudColor, cloudValues.highestCloudColor, cloudValues.highestCloudColor);
    }
}
