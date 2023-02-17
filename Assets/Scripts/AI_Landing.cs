using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Landing : AI_NPC
{
    public bool approach = true;
    public bool stop = false;

    public override void Execute(MovementController2D movement, CombatController combat, GameObject target){
        combat.Target = target;
        movement.cruise = 0.5f;

        float speed = movement.rb.velocity.magnitude;
        // Debug.Log("Speed" + speed);
        // get the directional relationship between target and npc
        Vector3 direction = (target.transform.position - transform.position).normalized;
        float dot = Vector3.Dot(direction, transform.right);
        // get distance from target to npc
        float distance = Vector3.Distance (target.transform.position, transform.position);
        // get current boolean values for statem
        bool dir = (dot > 0.95);
        bool ang = (Mathf.Abs(movement.SignedAngleTo(target.transform.position)) < 2);
        bool spd = (speed > 1);

        // Debug.Log(dir + " " + dist + " " + speed);
        if(stop) {
            Debug.Log("Stop Function");
            StopShip(movement, spd);
        }
        else if (approach)
        {
            // if not facing the target and not moving
            if(!dir && !spd){
                Debug.Log("Not facing, Not Moving");
                movement.vAxis = 0;
                movement.FaceTarget(target);
            } 
            // if not facing the target and moving
            // The second half of below OR needs to be a function of current speed and RotateSpeed
            else if ((!dir && spd) || (distance < speed * 1.65f)) {
                Debug.Log("Not facing, Moving");
                stop = true;
            } 
            // if facing the target and moving
            else if (dir && ang && !spd){
                Debug.Log("Facing, Not Moving");
                movement.FaceTarget(target);
                movement.vAxis = 1;
            }
            else if (dir && spd) {
                Debug.Log("Facing, Moving");
                movement.vAxis = 1;
                movement.FaceTarget(target);
            } else {
                Debug.Log("You should not be getting this error.");
                Debug.Log("Dot" + dot);
                Debug.Log(Mathf.Abs(movement.SignedAngleTo(target.transform.position)));
                movement.FaceTarget(target);
                movement.vAxis = 0;
            }
        }
    }

    virtual public void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Planet"){
            // Debug.Log("Touching Planet");
            approach = false;
            stop = true;
        }
    }

    void StopShip(MovementController2D movement, bool spd){
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
            stop = false;
            movement.vAxis = 0;
        } else {
            Debug.Log("Should not be getting this error");
        }
    }
}