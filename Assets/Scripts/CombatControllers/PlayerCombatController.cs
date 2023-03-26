using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatController : CombatController
{

    private int targetIndex = -1;
    // Update is called once per frame
    public override void Start(){
        base.Start();
        SetFirePoint();
        SetWeaponList();
    }
    
    void Update()
    {
        bulletPrefab = WeaponsList[0];
        var NPCs = this.GetComponentInParent<SystemManager>().spawnedNPCs;
        // Checks if player presses or holds the shoot button
        if (Target == null){
            targetIndex = 0;
            Target = NPCs[targetIndex];
        }
        if (Input.GetKeyDown(KeyCode.Tab)){
            targetIndex += 1;

            if (NPCs.Count <= targetIndex || Target == null){
                targetIndex = 0;
                Target = NPCs[targetIndex];
            }
            else {
                Target = NPCs[targetIndex].transform.GetChild(0).gameObject;
            }
        } 
        if((Input.GetButton("Jump")||Input.GetButtonDown("Jump")))
        {   
            // calls the shoot function
            Shoot();
        }
    }
 
    
}
