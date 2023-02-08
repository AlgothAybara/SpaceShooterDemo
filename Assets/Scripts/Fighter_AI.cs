using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter_AI : NPC_AI
{
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
