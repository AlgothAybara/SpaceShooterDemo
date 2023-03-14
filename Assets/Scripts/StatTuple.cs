using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StatTuple
{

    [SerializeField]
    public float currentValue, maxValue;

    [SerializeField]
    private float regenRate;    

    public float GetMax(){
        return maxValue;
    }

    public float GetCurrent(){
        return currentValue;
    }

    public float GetRegen(){
        return regenRate;
    }

    public void ResetCurrent() {
        currentValue = maxValue;
    }

    public void UpdateCurrent(float change) {
        currentValue += change;
        if(currentValue < 0.1){
            currentValue = 0;
        }
        // currentValue = Mathf.Clamp(change, 0, maxValue);
    }

    public void RegenCurrent(float custRate){
        if (currentValue < maxValue){
            currentValue+= custRate;
        }
        if (currentValue > maxValue){
            currentValue = maxValue;
        }
    }
    public void RegenCurrent() {
        if (currentValue < maxValue){
            currentValue+= regenRate;
        }
        if (currentValue > maxValue){
            currentValue = maxValue;
        }
    }

    

}
