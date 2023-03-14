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
        InvokeRepeating("ApplyRegen", 0f, 1f);
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

    private void ApplyRegen(){
        shield.RegenCurrent();
    }

     public void ApplyDamage(int damage){


        // Debug.Log(other.gameObject.GetComponent<ShipClass>().shield.currentValue);

        if(shield.GetCurrent() > 0)
        {
            shield.UpdateCurrent(damage);
        } 
        else
        {
            float armorDamage = damage * (armor.currentValue / armor.maxValue);

            armor.UpdateCurrent(armorDamage);
            integrity.UpdateCurrent(damage - armorDamage);
        }

        if(integrity.GetCurrent() <= 0){
            Debug.Log(gameObject + " Destroyed");
            Destroy(transform.parent.gameObject);
            Destroy(gameObject);
        }
    }
}