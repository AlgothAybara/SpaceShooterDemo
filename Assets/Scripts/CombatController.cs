using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public AudioSource lazer;

    public float rateOfFire = 0.5f;
    public float bulletForce = 20f;
    private float nextShot = 0;

    private float inverse = -1;
    // Update is called once per frame
    void Update()
    {
        // Checks if player presses or holds the shoot button
        if((Input.GetButton("Jump")||Input.GetButtonDown("Jump"))&&Time.time>nextShot)
        {   
            // sets the shot cooldown
            nextShot = Time.time + rateOfFire;
            // calls the shoot function
            Shoot(firePoint);
        }
    }

    public void Shoot(Transform firePoint)
    {
        // Creates a variation float
        float rand = Random.Range(-.1f, .1f);
        // creates variation Vector3
        Vector3 randVariation = new Vector3(rand, 0, 0);
        // Adds variation to direction vector3
        Vector3 dir = (randVariation + -firePoint.right).normalized;
        // instantiates bullet object
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        // gets bullet rigidbody
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        // sets bullet direction and adds instant force
        rb.AddForce(dir * bulletForce, ForceMode2D.Impulse);
        // Plays Audio Effect
        lazer.Play();
    }
}
