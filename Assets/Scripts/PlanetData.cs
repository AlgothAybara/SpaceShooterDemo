using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlanetData : MonoBehaviour
{
    // public GameObject planet;
    public Collision collision;
    public Inventory marketInventory;
    public Inventory shipInventory;
    public bool market, shipyward;

    public string Name;
    public string Desc;
    public Sprite planetSprite, menuSprite;

    // Start is called before the first frame update
    void Start()
    {
        // planet = GameObject.FindGameObjectWithTag("Planet");
    }

    // void OnTriggerEnter2D(Collider2D collision)
    // {
    //     return;
    // }
}

