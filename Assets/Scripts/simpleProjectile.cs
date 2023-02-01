using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleProjectile : MonoBehaviour
{
    public PolygonCollider2D shipCollider; //Collision


    public string projectileName; //Name of projectile

    public int damage; //How much damage?

    public float force; //How fast/slow?

    public float time; //How long before it dies/killed

    void OnCollisionEnter2D(Collision2D collision){
        Debug.Log(collision);
        // Destroys object
        Destroy(gameObject);
    }

    // Destroys object after timeout
    void Start(){
        Destroy(gameObject, time);
    }
}
