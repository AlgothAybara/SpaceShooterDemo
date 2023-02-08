using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Missile : simpleProjectile
{
    public GameObject target;
    public float rotationSpeed = 200f; //Turn rotation
    private Rigidbody2D rbody;
    public int changeTarget;

}
