using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StatTuple
{

    [SerializeField]
    private int maxValue, currentValue;

    [SerializeField]
    private float regenRate;    

    public int GetMax(){
        return maxValue;
    }

    public int GetCurrnet(){
        return currentValue;
    }

    public float GetRegen(){
        return regenRate;
    }

    public void ResetCurrent() {
        currentValue = maxValue;
    }

    public void UpdateCurrent(int change) {
        currentValue += change;
        // currentValue = Mathf.Clamp(change, 0, maxValue);
    }
}
