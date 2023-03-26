using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerData : CharacterData
{
    public Image shieldHealth; //UI image of shield health bar
    public Image armorHealth; //UI image of armor health bar
    public Image shipIntegrity; //UI image of ship's structural integrity.
    float lerpSpeed; //Math function to smooth out UI Image with health
    public Button LandButton;
    PauseMenu pauseMenu;


    public override void Start()
    {
        base.Start();
        LandButton.enabled = false;

    }

    //Color changes as health goes down for each respective health bar
    void ColorChanger()
    {
        //Shield will go from blue to red
        Color shieldHealthColor = Color.Lerp(Color.blue, Color.blue, (ship.shield.currentValue / ship.shield.maxValue));
        shieldHealth.color = shieldHealthColor;

        //Armor will go from green to red
        Color armorHealthColor = Color.Lerp(Color.red, Color.gray, (ship.armor.currentValue / ship.armor.maxValue));
        armorHealth.color = armorHealthColor;

        //Integrity will go from yellow to red
        Color shipIntegrityColor = Color.Lerp(Color.red, Color.green, (ship.integrity.currentValue / ship.integrity.maxValue));
        shipIntegrity.color = shipIntegrityColor;

    }

    void HealthBarFiller()
    {    
        //This will control the UI image to match health bar size with health stat
        shieldHealth.fillAmount = Mathf.Lerp(shieldHealth.fillAmount, ship.shield.currentValue / ship.shield.maxValue, lerpSpeed);
        armorHealth.fillAmount = Mathf.Lerp(armorHealth.fillAmount, ship.armor.currentValue / ship.armor.maxValue, lerpSpeed);
        shipIntegrity.fillAmount = Mathf.Lerp(shipIntegrity.fillAmount, ship.integrity.currentValue / ship.integrity.maxValue, lerpSpeed);
    }
    private void Update()
    {
        currentShip.transform.SetAsFirstSibling();
        //Lerp speed how fast the bar will decrease when damage is taken to ship
        lerpSpeed = 3f * Time.deltaTime;
        HealthBarFiller();
        ColorChanger();
    }

    //This handles a collision trigger for landing on planets.
    public void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Planet")
        {
            // Debug.Log("Arrived at Planet");
            if (Input.GetKeyDown(KeyCode.L))
            {
                if (pauseMenu.isGamePaused) //This is set to false to play
                {
                    pauseMenu.Resume();
                }
                else //If pushed, then it's set to true to pause
                {
                    pauseMenu.Pause();
                }
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D enter)
    {
        if (enter.gameObject.tag == "Planet") 
        {
            LandButton.enabled = true;
        }
        else
        {
            LandButton.enabled = false;
        }
    }

    public void OnTriggerExit2D(Collider2D exit)
    {
        if (exit.gameObject.tag == "Planet")
        {
             LandButton.enabled = false;
        }
        else
        {
             LandButton.enabled = true;
        }

    }
}

   

