using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatController : CombatController
{
    // Update is called once per frame
    void Update()
    {
        bulletPrefab = WeaponsList[0];
        // Checks if player presses or holds the shoot button
        if((Input.GetButton("Jump")||Input.GetButtonDown("Jump")))
        {   
            // calls the shoot function
            Shoot();
        }
    }
 
    void Start(){
        nextShot = 0;
        SetFirePoint(gameObject);
        bulletPrefab = WeaponsList[0];
    }
}
