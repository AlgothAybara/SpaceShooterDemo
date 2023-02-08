using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile_AI : MonoBehaviour
{
    public Transform target;
    public float rotationSpeed = 200f; //Turn rotation
    public float speed = 30f;
    private Rigidbody2D rbody;

    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rbody = GetComponent<Rigidbody2D>();
    }

    // UpdateFixed is necessary for tracking missle
    void FixedUpdate()
    {
        Vector2 direction = (Vector2)target.position - rbody.position;

        direction.Normalize();

        float RotateAmount = Vector3.Cross(direction, transform.up).z;

        rbody.angularVelocity = -RotateAmount * rotationSpeed;

        rbody.velocity = transform.up * speed;
        
    }

    void OnTriggerEnter2D()
    {
        if (Time.time >= 1_000_000) 
        {
            Destroy(gameObject);
            Debug.Log("Timeout");
        }
    }
}
