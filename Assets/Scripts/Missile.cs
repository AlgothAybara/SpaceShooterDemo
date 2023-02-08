using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Missile : simpleProjectile
{
    public float rotationSpeed; //Turn rotation
    public float maxSpeed;
    private Rigidbody2D rbody;
    public int changeTarget;

    public override void Start()
    {
        Destroy(gameObject, time);
    }
    // UpdateFixed is necessary for tracking missle
    void FixedUpdate()
    {
        // Vector2 direction = (Vector2)Target.transform.position - rbody.position;

        // direction.Normalize();

        // float RotateAmount = Vector3.Cross(direction, transform.up).z;

        // rbody.angularVelocity = -RotateAmount * rotationSpeed;
        Vector3 current = transform.right;
        Vector3 to = Target.transform.position - transform.position;
        transform.right = Vector3.RotateTowards(current, to, rotationSpeed * Time.deltaTime, 0.0f);

        // Rotate();
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

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.Equals(Target)){
            Destroy(gameObject);
            other.gameObject.GetComponent<ShipClass>().ApplyDamage(damage);
            Target = null;
        }
    }
}
