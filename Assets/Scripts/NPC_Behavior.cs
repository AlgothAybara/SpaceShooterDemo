using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Behavior : MonoBehaviour
{
    Transform player;
    public float hostility = 0;
    public float rotate_speed = 90f;

    private float last_distance = 0;


    // Update is called once per frame
    void Update()
    {
        if(player == null){
            GameObject go =  GameObject.Find("Player");

            if(go != null){
                player = go.transform;
            }
        }
        
        // Gets distance between objects
        float distance = Vector3.Distance (player.position, transform.position);
        // Sets state of fly by
        bool approach = true;

        // Chasing target and shooting
        if(approach){
            FacePlayer();
            // Movement Function Here

            // Checks if target in range
            if(distance < 10){
                Debug.Log("Shooting");
            } 
        }
        // Getting out of range for another fly-by
        else{
            if(distance <= 25){
                Debug.Log("Flying Away");
                // Movement Function Here
            }
            else if (distance > 25){
                Debug.Log("Turning Around");
                FacePlayer();

                // If target ship is approaching
                if(last_distance < distance){
                    approach = true;
                }
                //else if ()
            }
        }
        // checks if target is in range
        
        // checks if distance is increasing
        // else if(last_distance < distance)
        // {
            
        // }

        last_distance = distance;
        
    }

    Quaternion FacePlayer(){
        // gets difference between player and this GO's position
        Vector3 dir = player.position - transform.position;
        dir.Normalize();
        // Calculates the angle between 2 objects
        float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        // creates an angle object
        Quaternion target_dir = Quaternion.Euler(0,0,zAngle);
        // begins turning towards player
        transform.rotation = Quaternion.RotateTowards(transform.rotation, target_dir, rotate_speed*Time.deltaTime);

        return target_dir;
    }
    
    // Sets object z rotation to random degree
    void RandomRotation(){
        // gets copy of gameobject transform properties
        var euler = transform.eulerAngles;
        // sets z rotation to random angle
        euler.z = Random.Range(0f, 360f);
        // updates gameobject rotation
        transform.eulerAngles = euler;
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
            Vector3 movement = transform.right * Mathf.Clamp01(vAxis) * moveSpeed;
            // adds movement variable to velocity
            rb.AddForce(movement);

        }

        // constrains the object to be within certian x/y parameters
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -10000f, 10000f), Mathf.Clamp(transform.position.y, -10000f, 10000f), 0);

    }

    // Rotates an object roughly 180 directions from velocity
    void Rotate180(){
        // obtains smallest angle between velocity and 180 from it
        float angle = SignedAngleTo(-rb.velocity,transform.right,transform.forward);

        // checks if angle is within 2 degrees
        if (Mathf.Abs(angle) > 2){
            // returns the sign on the angle
            float sign = Signed(angle);
            // creates new vector 3 object with rotation
            Vector3 newRotation = new Vector3( 0, 0, -sign * rotateSpeed ); 
            // applies rotation object to gameobject's rotation
            transform.Rotate(Vector3.forward * newRotation.z); 
        } 
    }

    // Rotates object in direction of input
    void Rotation(){
        // checks if down button is pressed
        if( Input.GetAxis("Vertical") < 0 && rb.velocity.sqrMagnitude > 0.01f){
            // rotates the gameobject 180 degrees from velocity
            Rotate180();
        } else {
            // obtain rotation from input and rotate speed
            float rotation = -hAxis * rotateSpeed;
            // applies new rotation to game object
            transform.Rotate(Vector3.forward * rotation);
        }
    }

    // part of extension to Mathf library.
    // Finds the smallest angle between 2 vectors including its sign
    float SignedAngleTo(Vector3 a, Vector3 b, Vector3 up) {
     return Mathf.Atan2(
       Vector3.Dot(up.normalized, Vector3.Cross(a, b)),
       Vector3.Dot(a, b)) * Mathf.Rad2Deg;
   }

    // returns the sign of an object. Similar to another Mathf function, but can also return 0
    float Signed(float num){
        // returns 1 if num > 0
        if(num > 0){
           return 1;
       }
       // returns -1 if num < 0
       else if (num < 0)
       {
           return -1;
       }
       // returns 0 if num == 0
       else
       {
           return 0;
       }
   }
}
