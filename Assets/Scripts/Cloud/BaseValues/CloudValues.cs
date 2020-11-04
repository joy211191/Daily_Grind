using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CloudColorValues", menuName = "ScriptableObjects/CloudColorSettings", order = 1)]
public class CloudValues : ScriptableObject
{
    public float lowestCloudColor;
    public float highestCloudColor;
}
