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

    // Start is called before the first frame update
    public virtual void Start()
    {
        SetShip();
        // RandomRotation();
    }

    void SetShip(){
        // Instantiates player_data.Ship as a gameObject in the scene
        currentShip = Instantiate(this.Ship) as GameObject;
        // Sets the PlayerOnject as the parent of currentShip
        currentShip.transform.parent = this.transform;
    }
}
