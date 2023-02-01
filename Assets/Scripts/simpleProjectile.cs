using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleProjectile : MonoBehaviour
{
    public Sprite sprite; //Image

    public PolygonCollider2D projectileCollider; //Collision


    public string projectileName; //Name of projectile

    public int damage; //How much damage?

    public int speed; //How fast/slow?

    public float time; //How long before it dies/killed

    void expireProjectile() {
        return;
    }

    void onCollision() {
        return;
    }
}
