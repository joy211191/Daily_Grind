using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudCharges : MonoBehaviour
{
    public List<bool> boostList = new List<bool>();

    public float EffectiveBoostValue() {
        float boostValue= 1 + (GrayCheck() * 0.25f);
        return boostValue;
    }

    public Color ColorCheck() {
        float colorValue=0.9f-(GrayCheck()*0.25f);
        colorValue = Mathf.Clamp(colorValue, 0.3f, 0.9f);
        Color cloudColor = new Color(colorValue, colorValue, colorValue);
        return cloudColor;
    }
    
    public int GrayCheck() {
        int counter = 0;
        foreach (bool boostElement in boostList) {
            if (boostElement)
                counter++;
        }
        return counter;
    }
}
