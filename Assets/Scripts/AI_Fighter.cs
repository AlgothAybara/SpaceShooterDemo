using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Fighter : AI_NPC
{
    
    bool approach = false;
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
            // if (!dist && !ang && spd)  {
            //     Debug.Log("Stop");
            //     movement.vAxis = 1;
            // }
            // // If not facing the target and over 100 units away
            // else 
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
                combat.Shoot();
                // movement.FaceTarget(target);
            }
            else if (dir && dist) {
                movement.vAxis = 1;
                combat.Shoot();
            }
        }
       

    }

    // public bool approach = false;

    // public override void Move(MovementController2D movement, GameObject target)
    // {
    //     // Gets distance between objects
    //     float distance = Vector3.Distance (target.transform.position, transform.position);
    //     // Sets state of fly by

    //     Quaternion target_dir = FaceTarget(target);
    //     // Chasing target and shooting
        
    //     // Getting out of range for another fly-by
    //     if(distance <= 50){
    //         movement.Movement();
    //     }
    //     else {
    //         // If target ship is approaching
    //         if(last_distance < distance && distance > 10){
    //             approach = true;
    //         }
    //         // if ship is facing target
    //         else if (transform.rotation == target.transform.rotation){
    //             approach = true;
    //         }
    //         else{
    //             FaceTarget(target);
    //         }
    //     }

    //     last_distance = distance;
    // }

    // Quaternion FaceTarget(GameObject target){
    //     // gets difference between player and this GO's position
    //     Vector3 dir = target.transform.position - transform.position;
    //     dir.Normalize();
    //     // Calculates the angle between 2 objects
    //     float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    //     // creates an angle object
    //     Quaternion target_dir = Quaternion.Euler(0,0,zAngle);
    //     // begins turning towards player
    //     transform.rotation = Quaternion.RotateTowards(transform.rotation, target_dir, rotate_speed*Time.deltaTime);

    //     return target_dir;
    // }

    // public override void Attack(CombatController combat, GameObject target)
    // {
        // if(approach){
        //     if (transform.rotation == target_dir){
        //         movement.Movement();
        //     }

        //     if(distance < 1){
        //         approach = false;
        //     }
        //     // Checks if target in range
        //     if(distance < range*2 && Time.time>nextShot){           
        //         // sets the shot cooldown
        //         nextShot = Time.time + rateOfFire;
        //         // calls the shoot function
        //         Shoot(firePoint);
        //     } 
        // }
    // }
}
