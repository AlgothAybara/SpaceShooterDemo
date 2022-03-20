using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{   // Destroys object on collision
    public float time = 2;

    void OnCollisionEnter(Collision collision){
        // Destroys object
        Destroy(gameObject);
    }

    // Destroys object after timeout
    void Start(){
        Destroy(gameObject, time);
    }
}
