using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipClass : MonoBehaviour
{
    public string shipName, shipClass;
    public int maxSpeed, shipMass;
    public float turnRate, accelerationRate;

    public StatTuple armor, shield, fuel;

    void Awake () {
        armor.ResetCurrent();
        shield.ResetCurrent();
        fuel.ResetCurrent();
    }
}