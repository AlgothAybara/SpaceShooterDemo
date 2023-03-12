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
        // currentValue = Mathf.Clamp(change, 0, maxValue);
    }

    

}
