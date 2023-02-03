using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipClass : MonoBehaviour
{
    public Sprite sprite;
    public PolygonCollider2D shipCollider;
    public string shipName, shipClass;
    public int maxSpeed, shipMass;
    public float turnRate, accelerationRate, decelerationRate;

    public StatTuple armor, shield, fuel;

    void Awake () {
        armor.ResetCurrent();
        shield.ResetCurrent();
        fuel.ResetCurrent();
    }

     public void ApplyDamage(int damage){
        // Debug.Log(other.gameObject.GetComponent<ShipClass>().shield.currentValue);

        if(shield.GetCurrnet() > 0)
        {
            shield.UpdateCurrent(damage);
        } 
        else 
        {
            armor.UpdateCurrent(damage);
        }

        if(armor.GetCurrnet() < 0){
            Destroy(transform.parent.gameObject);
            Destroy(gameObject);
        }
    }
}