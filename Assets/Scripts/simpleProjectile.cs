using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleProjectile : MonoBehaviour
{
    public PolygonCollider2D shipCollider; //Collision
    public Transform parent;
    public string projectileName; //Name of projectile

    public int damage = 5; //How much damage?

    public float force; //How fast/slow?

    public int time; //How long before it dies/killed

    void OnTriggerEnter2D(Collider2D other){
        
        if (other.transform != parent){
            Destroy(gameObject);
            other.gameObject.GetComponent<ShipClass>().ApplyDamage(damage);
        }
    }
}
