using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public GameObject planet;
    public Collision collision;
    // Start is called before the first frame update
    void Start()
    {
        planet = GameObject.FindGameObjectWithTag("Planet");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Ship has reached Planet");
    }
}

