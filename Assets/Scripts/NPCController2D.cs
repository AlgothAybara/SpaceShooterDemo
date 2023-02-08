using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController2D : MovementController2D
{
    #region Declarations
    #endregion

    #region Unity Methods
 

    // Update is called once per frame
    void Update()
    {
       
        // Debug.Log(rb.velocity);
    }

#endregion
    
    #region Custom Methods

    // Sets variables to game inputs

    // Points GO towards the target object
    // Used in Hostile NPC AIs
    Quaternion FaceTarget(GameObject target){
        // gets difference between player and this GO's position
        Vector3 dir = target.transform.position - transform.position;
        dir.Normalize();
        // Calculates the angle between 2 objects
        float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        // creates an angle object
        Quaternion target_dir = Quaternion.Euler(0,0,zAngle);
        // begins turning towards player
        transform.rotation = Quaternion.RotateTowards(transform.rotation, target_dir, rotateSpeed*Time.deltaTime);

        return target_dir;
    }
   
   #endregion
}