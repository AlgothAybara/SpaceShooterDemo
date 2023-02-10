using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController2D : MonoBehaviour
{
    #region Declarations
    public float moveSpeed, rotateSpeed, maxSpeed;
    public Rigidbody2D rb;
    public ShipClass shipStats;
    public CharacterData cd;
    public float hAxis, vAxis;
    #endregion

    #region Unity Methods
    // Function runs when object is initialized
    public virtual void Start()
    {
        SetStats();
        // RandomRotation();
    }

    // Update is called once per frame
    void Update()
    {
        
        // Debug.Log(rb.velocity);
    }

    // Update is called at a fixed interval
    void FixedUpdate(){
        Rotation();
        Movement();
    }
#endregion
    
    #region Custom Methods
    void SetStats(){
        // Gets current ship from player data object
        cd = GetComponent<CharacterData>();

        // Gets the ship's stats and sets them as movement values
        shipStats = cd.Ship.GetComponentInChildren<ShipClass>();
        moveSpeed = shipStats.accelerationRate;
        maxSpeed = shipStats.maxSpeed;
        rotateSpeed = shipStats.turnRate;
        rb.mass = shipStats.shipMass;
    }

    
    // // Sets object z rotation to random degree
    // void RandomRotation(){
    //     // gets copy of gameobject transform properties
    //     var euler = transform.eulerAngles;
    //     // sets z rotation to random angle
    //     euler.z = Random.Range(0f, 360f);
    //     // updates gameobject rotation
    //     transform.eulerAngles = euler;
    // }


    public void Movement(){
        //Allows velocity decay when acceleration is 0
        if(vAxis == 0){
            float decelerationRate = shipStats.decelerationRate;
            rb.drag = decelerationRate;
        }
        else{
            rb.drag = 0;
        }

        // checks if object is going faster than max speed
        if(rb.velocity.magnitude > maxSpeed)
        {
            // sets object velocity to max speed
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
        else {
            // sets speed and direction of movement
            Vector2 movement = transform.right * Mathf.Clamp01(vAxis) * moveSpeed;
            // adds movement variable to velocity
            rb.AddForce(movement);

        }

        // constrains the object to be within certian x/y parameters
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -10000f, 10000f), Mathf.Clamp(transform.position.y, -10000f, 10000f), 0);

    }

    // Rotates an object roughly 180 directions from velocity
    public void Rotate180(){
        // obtains smallest angle between velocity and 180 from it
        float angle = SignedAngleTo(-rb.velocity);

        // checks if angle is within 2 degrees
        if (Mathf.Abs(angle) > 2){
            // returns the sign on the angle
            float sign = Signed(angle);
            // creates new vector 3 object with rotation
            Vector3 newRotation = new Vector3( 0, 0, -sign * rotateSpeed * Time.deltaTime); 
            // applies rotation object to gameobject's rotation
            transform.Rotate(Vector3.forward * newRotation.z); 
        } 
    }

    // Rotates object in direction of input
    public void Rotation(){
        // checks if down button is pressed
        if( Input.GetAxis("Vertical") < 0 && rb.velocity.sqrMagnitude > 0.01f){
            // rotates the gameobject 180 degrees from velocity
            Rotate180();
        } else {
            // obtain rotation from input and rotate speed
            float rotation = -hAxis * rotateSpeed * Time.deltaTime;
            // applies new rotation to game object
            transform.Rotate(Vector3.forward * rotation);
        }
    }

    // part of extension to Mathf library.
    // Finds the smallest angle between 2 vectors including its sign
    public float SignedAngleTo(Vector3 to) {
        Vector3 b = transform.right;
        Vector3 up = transform.forward;
        return Mathf.Atan2(
        Vector3.Dot(up.normalized, Vector3.Cross(to, b)),
        Vector3.Dot(to, b)) * Mathf.Rad2Deg;
   }

    // returns the sign of an object. Similar to another Mathf function, but can also return 0
    protected float Signed(float num){
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

   public virtual void FaceTarget(GameObject target){}
   #endregion
}