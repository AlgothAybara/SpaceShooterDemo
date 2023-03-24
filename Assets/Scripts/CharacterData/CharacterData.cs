using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData : MonoBehaviour
{
    public string Name;
    public GameObject Ship;
    public GameObject currentShip;
    public int Currency;
    public List<int> Relations_List;
    protected ShipClass ship;


    // Start is called before the first frame update
    public virtual void Start()
    {
        SetShip();
        // RandomRotation();

    }

    void SetShip(){
        // Instantiates player_data.Ship as a gameObject in the scene
        currentShip = Instantiate(this.Ship, this.transform.position, this.transform.rotation, this.transform) as GameObject;
        ship = currentShip.GetComponent<ShipClass>();
        // Sets the PlayerOnject as the parent of currentShip
        // currentShip.transform.parent = this.transform;
    }
}
