using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InfoMenu : MonoBehaviour
{
    private ShipClass ship;

    public GameObject ArmorText, ShieldText, IntegrityText, FuelText, TurnRateText, AccelerationRateText,
            DecelerationRateText, ShipClassText, ShipMassText, MaxSpeedText, ShipNameText;

    
    //List the path to access all the ship information
    void Start()
    {
        
        ship = GameObject.Find("SystemManager").transform.GetChild(0).GetComponent<PlayerData>().currentShip.GetComponent<ShipClass>();
        //ship = GameObject.Find("PlayerObject").GetComponent<PlayerData>().currentShip.GetComponent<ShipClass>();
        
    }

    //This will list all the values of each component into a string, then displayed in a textbox in PlayerDataMenu
    public void StorePlayerData()
    { 
        ShipNameText.GetComponent<Text>().text = "Ship Name: " + ship.shipName;
        
        ArmorText.GetComponent<Text>().text = "Armor Level: " + ship.armor.currentValue;

        ShieldText.GetComponent<Text>().text = "Shield Level: " + ship.shield.currentValue;

        IntegrityText.GetComponent<Text>().text = "Integrity Level: " + ship.integrity.currentValue;

        FuelText.GetComponent<Text>().text = "Fuel Level: " + ship.fuel.currentValue;

        TurnRateText.GetComponent<Text>().text = "Turn Rate: " + ship.turnRate;

        AccelerationRateText.GetComponent<Text>().text = "Acceleration Rate: " + ship.accelerationRate;

        DecelerationRateText.GetComponent<Text>().text = "Deceleration Rate: " + ship.decelerationRate;

        ShipClassText.GetComponent<Text>().text = "Ship Class: " + ship.shipClass;

        ShipMassText.GetComponent<Text>().text = "Ship Mass: " + ship.shipMass;

        MaxSpeedText.GetComponent<Text>().text = "Max Speed: " + ship.maxSpeed;

    }

    //Keep information updated consistantly throughout gameplay
    void Update()
    {
        StorePlayerData();
    }

}
