using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_AI : MovementController2D
{

    public GameObject Target;
    public int time;

    public NPCCombatController combatController;
    public NPCController2D movementController;


    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateFixed(){
        
    }


    void Movement(){
        // checks if object is going faster than max speed
        if(rb.velocity.magnitude > maxSpeed)
        {
            // sets object velocity to max speed
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
        else {
            // sets speed and direction of movement
            Vector3 movement = transform.right * moveSpeed;
            // adds movement variable to velocity
            rb.AddForce(movement);

        }
    }

    // Quaternion FaceTarget(){
    //     // gets difference between target and this GO's position
    //     Vector3 dir = Target.transform.position - transform.position;
    //     dir.Normalize();
    //     // Calculates the angle between 2 objects
    //     float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    //     // creates an angle object
    //     Quaternion target_dir = Quaternion.Euler(0,0,zAngle);
    //     // begins turning towards player
    //     transform.rotation = Quaternion.RotateTowards(transform.rotation, target_dir, rotate_speed*Time.deltaTime);

    //     return target_dir;
    // }
}
