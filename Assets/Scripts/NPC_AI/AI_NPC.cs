using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_NPC : MonoBehaviour
{
    // public GameObject target;

    public virtual bool Execute(MovementController2D movement, CombatController combat, GameObject target){
        Move(movement, target);
        Attack(combat, target);
        return false;
    }

    virtual public void Move(MovementController2D movement, GameObject target){

    }

    virtual public void Attack(CombatController combat, GameObject target){

    }

    protected bool StopShip(MovementController2D movement, bool spd){
        bool Vang = (Mathf.Abs(movement.SignedAngleTo(-movement.rb.velocity)) > 5);
        if(spd && Vang){
            // Debug.Log("180");
            movement.vAxis = 0;
            movement.Rotate180();
        }
        else if(spd) {
            // Debug.Log("Stopping");
            movement.vAxis = 1;
        } 
        else if (!spd){
            // Debug.Log("Done Stopping");
            movement.vAxis = 0;
            return false;
        } 
        // else if (!spd && approach){
        //     // Debug.Log("Done Stopping");
        //     stop = false;
        //     movement.vAxis = 0;
        // } else if (!spd && !approach){
        //     // Debug.Log("Landed");
        //     stop = false;
        //     movement.vAxis = 0;
        // } 
        else {
            Debug.Log("Should not be getting this error");
        }
        return true;
    }

}
