using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SimpleProjectile_2D : MonoBehaviour
{   

    //type of projectile    
    public string projectileName;

    //how much damange will it give?
    public int damage;

    //How long will it be viable? (in seconds)
    public int time;
    
    //How fast is it?
    public int speed;
    
    // Destroys object on collision
    void OnCollisionEnter(){
        // Destroys object
        Destroy();
    }

    // Destroys object after timeout
    void Start(){
        Destroy(time);
    }

}