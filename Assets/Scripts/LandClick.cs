using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LandClick : MonoBehaviour
{
    public Button LandButton;
    public GameObject PlayerObject;
    public GameObject PlanetObject;
    
    void Start(){
        Button btn = LandButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick(){
		RepositionPlayer();
	}

    public void RepositionPlayer(){
        this.PlayerObject.transform.position = this.PlanetObject.transform.position;
        RandomRotation(this.PlayerObject.transform);
        Debug.Log(PlanetObject);
    }

    // Sets object z rotation to random degree
    void RandomRotation(Transform playerPos){
        // gets copy of gameobject transform properties
        var euler = transform.eulerAngles;
        // sets z rotation to random angle
        euler.z = Random.Range(0f, 360f);
        // updates gameobject rotation
        playerPos.eulerAngles = euler;
    }
}

