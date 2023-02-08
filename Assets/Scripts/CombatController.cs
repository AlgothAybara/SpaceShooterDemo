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


    

    public void SetFirePoint(){
        // Gets current ship from parent data object
        firePoint = ParentObject.transform.GetChild(0).transform.GetChild(0).transform;
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
        bullet.GetComponent<simpleProjectile>().parent = ParentObject.transform.GetChild(0);
        bullet.GetComponent<simpleProjectile>().Target = Target.transform.GetChild(0).GetComponent<PolygonCollider2D>();
        bullet.GetComponent<simpleProjectile>().dir = dir;
       
    }
}
