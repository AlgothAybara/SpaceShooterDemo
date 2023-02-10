using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController2D : MovementController2D
{
    #region Declarations
    Vector3 newRotation = Vector3.zero;
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
    public override void FaceTarget(GameObject target){
        float angle = Mathf.Atan2(target.transform.position.y - transform.position.y, target.transform.position.x -transform.position.x ) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
    }
   
   #endregion
}