using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoMenu : MonoBehaviour
{
    private ShipClass ship;

    public GameObject ArmorText, ShieldText, IntegrityText, FuelText, TurnRateText, AccelerationRateText,
            DecelerationRateText, ShipClassText, ShipMassText, MaxSpeedText, ShipNameText;

    public string ArmorValue, ShieldValue, IntegrityValue, FuelValue, TurnRate, AccelerationRate,
                DecelerationRate, ShipClass, ShipMass, MaxSpeed, ShipName;

    
    //List the path to access all the ship information
    void Start()
    {
        
        ship = GameObject.Find("SystemManager").transform.GetChild(0).GetComponent<PlayerData>().currentShip.GetComponent<ShipClass>();
        //ship = GameObject.Find("PlayerObject").GetComponent<PlayerData>().currentShip.GetComponent<ShipClass>();
        
    }

    //This will list all the values of each component into a string, then displayed in a textbox in PlayerDataMenu
    public void StorePlayerData()
    { 
        ShipName = ShipNameText.GetComponent<Text>().text = "Ship Name: " + ship.shipName;
        
        ArmorValue = ArmorText.GetComponent<Text>().text = "Armor Level: " + ship.armor.currentValue;

        ShieldValue = ShieldText.GetComponent<Text>().text = "Shield Level: " + ship.shield.currentValue;

        IntegrityValue = IntegrityText.GetComponent<Text>().text = "Integrity Level: " + ship.integrity.currentValue;

        FuelValue = FuelText.GetComponent<Text>().text = "Fuel Level: " + ship.fuel.currentValue;

        TurnRate = TurnRateText.GetComponent<Text>().text = "Turn Rate: " + ship.turnRate;

        AccelerationRate = AccelerationRateText.GetComponent<Text>().text = "Acceleration Rate: " + ship.accelerationRate;

        DecelerationRate = DecelerationRateText.GetComponent<Text>().text = "Deceleration Rate: " + ship.decelerationRate;

        ShipClass = ShipClassText.GetComponent<Text>().text = "Ship Class: " + ship.shipClass;

        ShipMass = ShipMassText.GetComponent<Text>().text = "Ship Mass: " + ship.shipMass;

        MaxSpeed = MaxSpeedText.GetComponent<Text>().text = "Max Speed: " + ship.maxSpeed;

    }

    //Keep information updated consistantly throughout gameplay
    void Update()
    {
        StorePlayerData();
    }

}
