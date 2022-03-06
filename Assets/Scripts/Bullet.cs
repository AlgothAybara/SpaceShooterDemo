using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{   // Destroys object on collision
    void OnCollisionEnter(Collision collision){
        // Destroys object
        Destroy(gameObject);
    }

    // Destroys object after timeout
    void Start(){
        Destroy(gameObject, 5f);
    }
}
