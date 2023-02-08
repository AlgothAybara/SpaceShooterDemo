using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleProjectile : MonoBehaviour
{
    public Transform parent;
    public string projectileName; //Name of projectile
    public PolygonCollider2D Target;
    public Rigidbody2D rb;
    public Vector3 dir;

    public float rateOfFire = 0.5f;

    public int damage = 5; //How much damage?

    public float force; //How fast/slow?

    public int time; //How long before it dies/killed

    virtual public void Start() {
         // gets bullet rigidbody
        // sets bullet direction and adds instant force
        rb.AddForce(dir * force, ForceMode2D.Impulse);
        Destroy(gameObject, time);
    }


    virtual public void OnTriggerEnter2D(Collider2D other){
        
        if (other.transform != parent){
            Destroy(gameObject);
            other.gameObject.GetComponent<ShipClass>().ApplyDamage(damage);
        }
    }
}
