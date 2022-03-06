using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollUV : MonoBehaviour
{
    // sets default parallax coefficient
    public float parallax = 2f;

    // Update is called once per frame
    void Update()
    {
        //obtain object for mesh
        MeshRenderer mr = GetComponent<MeshRenderer>();
        //obtains object's material
        Material mat = mr.material;
        // sets a 2D vector to move material
        Vector2 offset = mat.mainTextureOffset;
        // updates the x and y of the offset object
        offset.x = transform.position.x / transform.localScale.x / parallax;
        offset.y = transform.position.y / transform.localScale.y / parallax;

        // applies material offset vector to mesh material
        mat.mainTextureOffset = offset;
    }
}
