using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetMenu : MonoBehaviour
{
    private PlanetData planet;

    public GameObject PlanetName, PlanetDesc, PlanetImage;
    
    //List the path to access all the ship information
    void Start()
    {
        
        planet = GameObject.Find("SystemManager").transform.GetChild(0).GetComponent<PlayerData>().currentShip.GetComponent<PlanetData>();
        
    }

    //This will list all the values of each component into a string, then displayed in a textbox in PlayerDataMenu
    public void StorePlanetData()
    { 
        PlanetName.GetComponent<Text>().text = planet.Name;
        
        PlanetDesc.GetComponent<Text>().text = planet.Desc;

        PlanetImage.GetComponent<Image>().sprite = planet.menuSprite;
    }

    //Keep information updated consistantly throughout gameplay
    void Update()
    {
        StorePlanetData();
    }

}
