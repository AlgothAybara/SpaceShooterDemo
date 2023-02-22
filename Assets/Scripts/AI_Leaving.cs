using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Leaving : AI_NPC
{
    public bool stop = false;

    public override void Execute(MovementController2D movement, CombatController combat, GameObject target){
        combat.Target = target;
        movement.cruise = 0.5f;

        // get speed
        float speed = movement.rb.velocity.magnitude;
        // get the distance from origin
        float x = transform.position.x;
        float y = transform.position.y;
        float distance = Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(y, 2));
        // check angle from origin
        bool dir = (Mathf.Abs(movement.SignedAngleTo(transform.position)) < 2);
        //check speed
        bool spd = (speed > 1);
        //check distance
        bool dist = (distance > 50);

        if(stop) {
            Debug.Log("Stop Function");
            StopShip(movement, spd);
        }
        else if (dist)
        {
            // if moving while at distance
            if(spd){
                movement.vAxis = 0;
                stop = true;
            } 
            // if not facing while at distance
            else if (!dir) {
                movement.vAxis = 0;
                float angle = movement.SignedAngleTo(transform.position);
                movement.RotateTo(angle);
            } 
            // if not moving and facing while at distance
            else if (dir){
                Destroy(gameObject);
            }
            else {
                Debug.Log("You should not be getting this error.");
                Debug.Log("Dir:" + dir);
                Debug.Log("Spd:"+spd);
                Debug.Log("Dist:"+dist);
                movement.vAxis = 0;
            }
        } 
        // if under distance
        else 
        {
            movement.vAxis = 1;
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