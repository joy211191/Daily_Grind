using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudCharges : MonoBehaviour
{
    CloudMovement cloudMovement;
    public List<bool> boostList = new List<bool>();
    float timer = 3;
    bool noInput;
    bool grayCloud;
    bool updated;
    bool boostUpdated;

    [SerializeField]
    CloudValues cloudValues;

    [SerializeField]
    AudioSource chargeSound;

    private void Awake() {
        cloudMovement = GetComponent<CloudMovement>();
    }

    public float EffectiveBoostValue() {
        float boostValue= 1 + (GrayCheck() * 0.25f);
        return boostValue;
    }

    public Color ColorCheck() {
        float colorValue= cloudValues.highestCloudColor -(GrayCheck()*0.25f);
        colorValue = Mathf.Clamp(colorValue, cloudValues.lowestCloudColor,cloudValues.highestCloudColor);
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

    private void Update() {
        if (!boostUpdated) {
            if (noInput)
                timer -= Time.deltaTime;
            else
                timer = 3;

            if (timer <= 0) {
                updated = false;
                List<bool> tempList = new List<bool>();
                foreach (bool item in boostList) {
                    tempList.Add(item);
                }
                for (int i = 0; i <boostList.Count-1; i++) {
                    boostList[i+1]= tempList[i];
                }
                boostList[0] = grayCloud;
                boostUpdated = true;
            }
        }
        if (!updated && timer <= 0) {
            if (!chargeSound.isPlaying)
                chargeSound.Play();
            updated = cloudMovement.EnergyRecharge();
        }
        else
            chargeSound.Stop();
        
    }

    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.tag == "Cloud") {
            noInput = !Input.anyKey;
            grayCloud = collision.gameObject.GetComponent<CloudValue>().gray;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        boostUpdated = false;
        updated = false;
        timer = 3;
    }
}
