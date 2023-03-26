using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    ShipClass ship;
    public Transform firePoint;

    public GameObject bulletPrefab;
    public GameObject ParentObject;
    public GameObject Target;
    public List<GameObject> WeaponsList;
    public float nextShot = 0;
    public float RoF;

    public virtual void Start(){
        nextShot = 0;        
    }

    
    public void SetFirePoint(){
        // Gets current ship from parent data object
        // Debug.Log("fish");
        // Debug.Log(transform.GetChild(0).transform);
        // Debug.Log(transform.GetChild(0).transform.GetChild(0).transform);
        firePoint = transform.GetChild(0).transform.GetChild(0).transform;
        SetWeaponList();
        // Debug.Log(firePoint);

    }

    public void SetWeaponList(){
        WeaponsList = ParentObject.transform.GetChild(0).GetComponent<ShipClass>().WeaponsList;
        // Debug.Log(WeaponsList[0]);
        if (WeaponsList.Count > 0) {
            bulletPrefab = WeaponsList[0];
            RoF = bulletPrefab.GetComponent<Projectile>().rateOfFire;
        }
    }

    public void Shoot()
    {
        if(Time.time> nextShot && Time.timeScale != 0 && bulletPrefab != null)
        {   
            float variation = bulletPrefab.GetComponent<Projectile>().rand;
            // sets the shot cooldown
            nextShot = Time.time + RoF;
            // Creates a variation float
            float rand = Random.Range(-variation, variation);
            // creates variation Vector3
            Vector3 randVariation = new Vector3(rand, 0, 0);
            // Adds variation to direction vector3
            Vector3 dir = (randVariation + -firePoint.right).normalized;
            // instantiates bullet object
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.GetComponent<Projectile>().parent = ParentObject.transform.GetChild(0);
            bullet.GetComponent<Projectile>().Target = Target;
            bullet.GetComponent<Projectile>().dir = dir;
        }
    }
}   

