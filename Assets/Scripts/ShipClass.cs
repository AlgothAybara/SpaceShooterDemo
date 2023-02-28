using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipClass : MonoBehaviour
{
    public Sprite sprite;
    public PolygonCollider2D shipCollider;
    public string shipName, shipClass;
    public int maxSpeed, shipMass;
    public float turnRate, accelerationRate, decelerationRate;
    

    public StatTuple armor, shield, fuel, integrity;

    void Start () {
        armor.ResetCurrent();
        shield.ResetCurrent();
        fuel.ResetCurrent();
        integrity.ResetCurrent();
    }

    void Update()
    {
        if (shield.currentValue > shield.maxValue) 
        {
            shield.GetMax();
        }

        if (armor.currentValue > armor.maxValue)
        {
            armor.GetMax();
        }

        if (integrity.currentValue > integrity.maxValue)
        {
            integrity.GetMax();
        }
    }

    

     public void ApplyDamage(int damage){
        // Debug.Log(other.gameObject.GetComponent<ShipClass>().shield.currentValue);

        if(shield.GetCurrent() > 0)
        {
            shield.UpdateCurrent(damage);
        } 
        else
        {
            armor.UpdateCurrent(damage);
            if (armor.currentValue <= 75)
            {
                integrity.UpdateCurrent(damage);
            }  
        }

        if(armor.GetCurrent() < 0){
            Destroy(transform.parent.gameObject);
            Destroy(gameObject);
        }
    }
}