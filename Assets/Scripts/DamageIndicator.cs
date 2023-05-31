using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageIndicator : MonoBehaviour
{
    public GameObject DamageText;

    public int dmg;

    void Start()
    {
        //Destroys the gameobject after 1 second
        Destroy(gameObject, 1f);
    }

    void Update()
    {
        StoreDamage();

        //makes the number float upwards at set speed, and sets positioning
        float moveYSpeed = 5f;
        transform.position += new Vector3(0,moveYSpeed, 0) * Time.deltaTime;
    }


    //This will store the damage input and set it to a string to be seen on-screen
    public void StoreDamage()
    { 
        //Debug.Log(DamageText.GetComponent<TextMesh>().text);
        DamageText.GetComponent<TextMesh>().text = dmg.ToString();

    }

}