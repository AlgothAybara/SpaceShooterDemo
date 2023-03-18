using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Fighter : AI_NPC
{
    
    bool approach = false;
    bool stop = false;

    public override bool Execute(MovementController2D movement, CombatController combat, GameObject target){
        if (target == null) {
            // Debug.Log("Target not found");
            return true;
        }
        combat.Target = target;

        float speed = movement.rb.velocity.magnitude;
        // get the directional relationship between target and npc
        Vector3 direction = (target.transform.position - transform.position).normalized;
        float dot = Vector3.Dot(direction, transform.right);
        float Mdot = Vector3.Dot(movement.rb.velocity.normalized, transform.right);
        // get distance from target to npc
        float distance = Vector3.Distance (target.transform.position, transform.position);
        // get current boolean values for statem
        bool dir = (dot >= 0.9995);
        bool Mdir = (Mdot >= 0.9);
        bool Bdir = (dot >= 0.8);
        bool negDir = (dot < -0.5);
        bool dist = (distance < 50);
        bool spd = (speed > 10);

        // Debug.Log("\n Stop: " + stop + "Approach: " + approach
        //     + "\n Dist: " + dist + " Distance: " + distance
        //     + "\n Spd: " + spd + " Speed: " + movement.GetSpeed()
        //     + "\n Dir: " + dir + " Dot: " + dot
        //     + "\n MDir: " + Mdir + " MDot: " + Mdot
        //     + "\n Velocity: " + movement.rb.velocity
        // );
        
        if(stop) {
            // Debug.Log("Stop");
            stop = StopShip(movement, spd);
        }
        else if (!approach) {
            // if further than 50, and faster than 10
            if(!dist && spd) {
                // Debug.Log("Set Stop");
                stop = true;
            }
            // if further than 50, slower than 10, and facing target
            else if (!dist && !spd && dir){
                // Debug.Log("A, !a");
                approach = true;
            }
            // if further than 50, slower than 10, and not facing target
            else if(!dist && !spd && !dir) {
                // Debug.Log("FT, !a");
                movement.FaceTarget(target);
            }
            // if less
            else {
                // Debug.Log("Move, !a \n");
                // Debug.Log(target);
                movement.vAxis = 1;
            }
            
        }
        else if (approach){
            // if (!dist && !ang && spd)  {
            //     Debug.Log("Stop");
            //     movement.vAxis = 1;
            // }
            if (!Mdir && !dist && spd){
                approach = false;
            }
            // If not facing the target and over 100 units away
             if(!dir && !dist && Mdir){
                // Debug.Log("FT, a");  
                movement.vAxis = 0;
                movement.FaceTarget(target);
            } 
            // if facing the target and over 100 meters away
            else if (dir && !dist) {
                // Debug.Log("A, a");
                movement.vAxis = 1;
            } 
            // if facing the target and under 100 meters away
            else if (dir && dist){
                // Debug.Log("S, a");
                movement.vAxis = 1;
                combat.Shoot();
            }
            // if not facing the target and under 100 meters away, correctable
            else if (!dir && dist && Bdir) {
                // Debug.Log("SFT, a");
                movement.vAxis = 1;
                combat.Shoot();
                movement.FaceTarget(target);
            }
            // if not facing the target and under 100 meters away, not correctable
            else if (!dir && dist && !Bdir) {
                // Debug.Log("OC");
                approach = false;
            }
            // if not facing the target and under 50 units away
            else if (negDir && dist) {
                // Debug.Log("Triggered?");
                // Debug.Log("Flying Away");
                movement.vAxis = 1;
                approach = false;
            } 
            else {
                // Debug.Log("Catch all");
                approach = false;
            }
        }
       return false;
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
