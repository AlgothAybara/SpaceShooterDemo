using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MovementController2D
{
    #region Declarations
    #endregion

    #region Unity Methods

    // Update is called once per frame
    void Update()
    {
        GetInput();
        
        // Debug.Log(rb.velocity);
    }

#endregion
    
    #region Custom Methods
    // Sets variables to game inputs
    void GetInput(){
        hAxis = Input.GetAxis("Horizontal");
        vAxis = Input.GetAxis("Vertical");
    }

   #endregion
}