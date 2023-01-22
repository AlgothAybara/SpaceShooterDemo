using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public string shipName, shipClass;
       
    //MaxFuel, currentFuel, fuelRegenRate
    public (int, int, float, float) fuelProperties, shieldProperties, armorProperties;

    //maxSpeed, shipMass, turnRate, accelerationRate
    public (int, int, float, float) shipProperties;
   
}



