using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Missile : Projectile
{
    public float rotationSpeed; //Turn rotation
    public float maxSpeed;
    private Rigidbody2D rbody;
    public int changeTarget;

    public override void Start()
    {
        if (Target == null){
            Target = GameObject.Find("EmptyTarget");
        }
        Destroy(gameObject, time);
    }
    // UpdateFixed is necessary for tracking missle
    void FixedUpdate()
    {
        if (Target == null){
            Target = GameObject.Find("EmptyTarget");
        }
        FaceTarget();
        Move();
    }

    void Move() 
    {
        // checks if object is going faster than max speed
        if(rb.velocity.magnitude > maxSpeed)
        {
            // sets object velocity to max speed
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
        else {
            // sets speed and direction of movement
            Vector2 movement = transform.right * force;
            // adds movement variable to velocity
            rb.AddForce(movement);

        }

        // constrains the object to be within certian x/y parameters
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -10000f, 10000f), Mathf.Clamp(transform.position.y, -10000f, 10000f), 0);

    }

    void FaceTarget(){
        if(Target.name != "EmptyTarget" || Target == null){
            Vector3 current = transform.right;
            Vector3 to = Target.transform.position - transform.position;
            transform.right = Vector3.RotateTowards(current, to, rotationSpeed * Time.deltaTime, 0.0f);
        }
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {        
        if (other.transform == parent || other.gameObject.tag == "Planet" || other.gameObject.tag == "Projectile" ){
            return;
        }
        if (Target.tag == "Empty" && other.gameObject.tag == "Ship"){
            Destroy(gameObject);
            other.gameObject.GetComponent<ShipClass>().ApplyDamage(damage);
            Target = null;
        }
        else if (other.gameObject == Target){
            Destroy(gameObject);
            other.gameObject.GetComponent<ShipClass>().ApplyDamage(damage);
            Target = null;
        } 
    }
}
