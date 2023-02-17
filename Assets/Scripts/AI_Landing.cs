using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Landing : AI_NPC
{
    public bool approach = true;

    public override void Execute(MovementController2D movement, CombatController combat, GameObject target){
        combat.Target = target;

        float speed = movement.rb.velocity.magnitude;
        // get the directional relationship between target and npc
        Vector3 direction = (target.transform.position - transform.position).normalized;
        float dot = Vector3.Dot(direction, transform.right);
        // get distance from target to npc
        float distance = Vector3.Distance (target.transform.position, transform.position);
        // get current boolean values for statem
        bool dir = (dot == 1);
        bool negDir = (dot < -0.5);
        bool dist = (distance < 50);
        bool ang = (Mathf.Abs(movement.SignedAngleTo(target.transform.position)) > 2);
        bool spd = (speed > 10);

        // Debug.Log(dir + " " + dist + " " + speed);

        if (!approach) {
            // turn ship 180 degrees
            if(!dist && ang && spd) {
                // Debug.Log("180");
                movement.vAxis = 0;
                movement.Rotate180();
            }
            else if (!(Mathf.Abs(movement.SignedAngleTo(target.transform.position)) > 2)){
                approach = true;
                // Debug.Log("Now Approaching");
            }
            // if not facing the target and under 100 units away
            else if (negDir && dist) {
                // Debug.Log("Flying Away");
                movement.vAxis = 1;
                approach = false;
            } 
            
        }
        else if (approach){

            if(!dir && !dist){
                // Debug.Log("Not facing, OOR");
                movement.vAxis = 0;
                movement.FaceTarget(target);
            } 
            // if facing the target and over 100 meters away
            else if (dir && !dist) {
                // Debug.Log("Facing, OOR");
                movement.vAxis = 1;
            } 
            // if facing the target and under 100 meters away
            else if (!dir && dist){
                // Debug.Log("Correcting course");
                movement.vAxis = 1;
                // movement.FaceTarget(target);
            }
            else if (dir && dist) {
                movement.vAxis = 1;
            }
        }
    }

    virtual public void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Planet"){
            Debug.Log("Touching Planet");
            approach = false;
        }
    }
}

    // public override void Execute(MovementController2D movement, CombatController combat, GameObject target){
    //     Debug.Log("Execute");
    //     float speed = movement.rb.velocity.magnitude;
    //     // get the directional relationship between target and npc
    //     Vector3 direction = (target.transform.position - transform.position).normalized;
    //     float dot = Vector3.Dot(direction, transform.right);
    //     // get distance from target to npc
    //     float distance = Vector3.Distance (target.transform.position, transform.position);
        
    //     // get current boolean values for statem
    //     bool dir = (dot > 0.8);
    //     bool ang = (Mathf.Abs(movement.SignedAngleTo(target.transform.position)) > 10);
    //     bool spd = (speed > 2);
    //     bool Vang = (Mathf.Abs(movement.SignedAngleTo(-movement.rb.velocity)) > 25);

    //     if(approach){
    //         if(!dir && !Vang){
    //             Debug.Log("Not facing, OOR");
    //             movement.vAxis = 0;
    //             movement.FaceTarget(target);
    //         } 
    //         else if(!dir && Vang) {
    //             StopShip(movement, spd, Vang);
    //         }
    //         // if facing the target and over 100 meters away
    //         else if (dir && !Vang) {
    //             Debug.Log("Facing, OOR");
    //             movement.vAxis = 1;
    //         } 
    //     } else {
    //         if(spd || Vang){
    //             StopShip(movement, spd, Vang);
    //         }
    //         else{
    //             Debug.Log("Stopped");
    //         }
    //     }
    // }

    // void StopShip(MovementController2D movement, bool spd, bool Vang){
    //     if(spd && Vang){
    //         Debug.Log("180");
    //         movement.vAxis = 0;
    //         movement.Rotate180();
    //     }
    //     else if(spd) {
    //         Debug.Log("Stopping");
    //         movement.vAxis = 1;
    //     }
    // }

    

    