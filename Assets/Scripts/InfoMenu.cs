using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoMenu : MonoBehaviour
{

    private ShipClass ship;
    StatTuple armor, shield, integrity;
    public GameObject inputField;

    public GameObject ArmorText;
    public GameObject ShieldText;

    public GameObject IntegrityText;

    public string ArmorValue;
    public string ShieldValue;
    public string IntegrityValue;

    void Start()
    {
        
        ship = GameObject.Find("SystemManager").transform.GetChild(0).GetComponent<PlayerData>().currentShip.GetComponent<ShipClass>();
        //ship = GameObject.Find("PlayerObject").GetComponent<PlayerData>().currentShip.GetComponent<ShipClass>();
        
    }
    public void StorePlayerData()
    { 
        // newShipName = inputField.GetComponent<Text>().text;
        // textDisplay.GetComponent<Text>().text = "Ship Name: " + newShipName;
        
        ArmorValue = ArmorText.GetComponent<Text>().text = "Armor Level: " + ship.armor.currentValue;

        ShieldValue = ShieldText.GetComponent<Text>().text = "Shield Level: " + ship.shield.currentValue;

        IntegrityValue = IntegrityText.GetComponent<Text>().text = "Integrity Level: " + ship.integrity.currentValue;

    }

    void Update()
    {
        StorePlayerData();
    }

}
