using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject ParentObject;
    public GameObject Target;
    public List<GameObject> WeaponsList;
    public float nextShot = 0;

    // void Start(){
    //     nextShot = 0;
    //     SetFirePoint();
    //     bulletPrefab = WeaponsList[0];
    // }

    public void SetFirePoint(GameObject caller){
        // Gets current ship from parent data object
        firePoint = ParentObject.transform.GetChild(0).transform.GetChild(0).transform;
        Debug.Log(caller);

    }

    public void Shoot()
    {
        if(Time.time> nextShot)
        {   
            // sets the shot cooldown
            nextShot = Time.time + bulletPrefab.GetComponent<Projectile>().rateOfFire;
            // Creates a variation float
            float rand = Random.Range(-.1f, .1f);
            // creates variation Vector3
            Vector3 randVariation = new Vector3(rand, 0, 0);
            // Adds variation to direction vector3
            Vector3 dir = (randVariation + -firePoint.right).normalized;
            // instantiates bullet object
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.GetComponent<Projectile>().parent = ParentObject.transform.GetChild(0);
            bullet.GetComponent<Projectile>().Target = Target.transform.GetChild(0).GetComponent<PolygonCollider2D>();
            bullet.GetComponent<Projectile>().dir = dir;
        }
    }
}
