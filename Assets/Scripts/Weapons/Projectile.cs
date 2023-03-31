using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Transform parent;
    public string projectileName; //Name of projectile
    public GameObject Target;
    public Rigidbody2D rb;
    public Vector3 dir;

    public GameObject damageIndicator; 
    public float rateOfFire = 0.5f;
    public int damage = 5; //How much damage?
    public float force; //How fast/slow?
    public int time; //How long before it dies/killed
    public float rand; //Random variation used in instantiation

    virtual public void Start() {
         // gets bullet rigidbody
        // sets bullet direction and adds instant force
        if (Target == null){
            Target = GameObject.Find("EmptyTarget");
        }
        rb.AddForce(dir * force, ForceMode2D.Impulse);
        gameObject.tag = "Projectile";
        Destroy(gameObject, time);
    }

    void Update(){
        if (Target == null){
            Target = GameObject.Find("EmptyTarget");
        }
    }

    protected void DisplayDamageIndicators(int dmg){
        if (GetComponent<Renderer>().isVisible)
            {
                var di = Instantiate(damageIndicator, transform.position, Quaternion.identity);
                di.GetComponent<DamageIndicator>().dmg = dmg;
            }
    }

    virtual public void OnTriggerEnter2D(Collider2D other){
        
        if (other.transform != parent && other.gameObject.tag != "Planet" && other.gameObject.tag != "Projectile"){
            var dmg = other.gameObject.GetComponent<ShipClass>().ApplyDamage(damage);
            DisplayDamageIndicators(dmg);
            Destroy(gameObject);
        }
        if(gameObject.tag == "Planet")
        {
            return;
        }

    }
}
