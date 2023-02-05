using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public string Name;
    public GameObject Ship;
    public int Currency;
    public List<int> Relations_List;


     // Function runs when object is initialized
    public virtual void Start()
    {
        SetShip();
        // RandomRotation();
    }

    void SetShip(){
        // Instantiates player_data.Ship as a gameObject in the scene
        GameObject currentShip = Instantiate(this.Ship) as GameObject;
        // Sets the PlayerOnject as the parent of currentShip
        currentShip.transform.parent = this.transform;
    }

}
