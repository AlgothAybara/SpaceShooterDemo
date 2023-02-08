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
        if((Input.GetButton("Jump")||Input.GetButtonDown("Jump"))&&Time.time> nextShot)
        {   
            // sets the shot cooldown
            nextShot = Time.time + bulletPrefab.GetComponent<simpleProjectile>().rateOfFire;
            // calls the shoot function
            Shoot(firePoint);
        }
    }

    void Start(){
        nextShot = 0;
        SetFirePoint();
        bulletPrefab = WeaponsList[0];
    }
}
