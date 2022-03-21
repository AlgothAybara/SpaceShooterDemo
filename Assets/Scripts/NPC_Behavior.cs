using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Behavior : MonoBehaviour
{
    public float hostility = 0;

#region Movement Variables
    public float rotate_speed = 5f;
    public float maxSpeed = 100f;
    public float moveSpeed = 50f;
    public bool approach = false;
    public Rigidbody rb;

    private float last_distance = 0;
    private Transform player;
#endregion

#region Shooting Variables
    public Transform firePoint;
    public GameObject bulletPrefab;
    public AudioSource lazer;
    public float range = 20f;
    public float rateOfFire = 0.1f;
    public float bulletForce = 20f;

    private float nextShot = 0;
    private float inverse = -1;
#endregion

    // Start runs when attached assets are initiated
    void Start(){
        RandomRotation();
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null){
            GameObject go =  GameObject.Find("Player");

            if(go != null){
                player = go.transform;
            }
        }
        
        MidFighter_Attack_AI();
    }

    // Points GO towards the player object
    // Used in Hostile NPC AIs
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
            Vector3 movement = transform.right * moveSpeed;
            // adds movement variable to velocity
            rb.AddForce(movement);

        }
    }

    public void Shoot(Transform firePoint)
    {
        float force = bulletForce + rb.velocity.magnitude;
        Debug.Log(force);
        // Creates a variation float
        float rand = Random.Range(-.1f, .1f);
        // creates variation Vector3
        Vector3 randVariation = new Vector3(rand, 0, 0);
        // Adds variation to direction vector3
        Vector3 dir = (randVariation + -firePoint.right).normalized;
        // instantiates bullet object
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        // gets bullet rigidbody
        Rigidbody bullet_rb = bullet.GetComponent<Rigidbody>();
        // sets bullet direction and adds instant force
        bullet_rb.AddForce(dir * force, ForceMode.Impulse);
        // Plays Audio Effect
        lazer.Play();
    }

    void MidFighter_Attack_AI(){
        // Gets distance between objects
        float distance = Vector3.Distance (player.position, transform.position);
        // Sets state of fly by

        Quaternion target = FacePlayer();
        // Chasing target and shooting
        if(approach){
            if (transform.rotation == target){
                Movement();
            }

            if(distance < 1){
                approach = false;
            }
            // Checks if target in range
            if(distance < range*2 && Time.time>nextShot){           
                // sets the shot cooldown
                nextShot = Time.time + rateOfFire;
                // calls the shoot function
                Shoot(firePoint);
            } 
        }
        // Getting out of range for another fly-by
        else{
            if(distance <= 50){
                Movement();
            }
            else {
                // If target ship is approaching
                if(last_distance < distance && distance > 10){
                    approach = true;
                }
                // if ship is facing target
                else if (transform.rotation == target){
                    approach = true;
                }
                else{
                    FacePlayer();
                }
            }
        }

        last_distance = distance;
    }
}
