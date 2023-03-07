using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatController : CombatController
{
    private int targetIndex = -1;
    // Update is called once per frame
    void Update()
    {
        bulletPrefab = WeaponsList[0];
        // Checks if player presses or holds the shoot button
        if (Input.GetKeyDown(KeyCode.Tab)){
            var NPCs = this.GetComponentInParent<SystemManager>().spawnedNPCs;
            targetIndex += 1;

            if (NPCs.Count <= targetIndex || Target == null){
                targetIndex = 0;
            }
            Target = NPCs[targetIndex];
        } 
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
