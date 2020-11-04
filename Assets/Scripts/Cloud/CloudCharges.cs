using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudCharges : MonoBehaviour
{
    public List<BoostClass> boostList = new List<BoostClass>();

    public float EffectiveBoostValue() {
        float boostValue= 1 + (GrayCheck() * 0.25f);
        return boostValue;
    }

    public Color ColorCheck() {
        float colorValue=0.9f-(GrayCheck()*0.25f);
        Color cloudColor = new Color(colorValue, colorValue, colorValue);
        return cloudColor;
    }
    
    public int GrayCheck() {
        int counter = 0;
        foreach (BoostClass boostElement in boostList) {
            if (boostElement.gray)
                counter++;
        }
        return counter;
    }
    
}
