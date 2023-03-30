using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShipButton : MonoBehaviour
{
    public GameObject Ship;
    public GameObject Player;
    public Button ship_button;

    
    void Start(){
        Button btn = ship_button.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick(){
		Player.transform.GetComponent<PlayerData>().SetShip(Ship);
        Player.transform.GetComponent<PlayerCombatController>().SetFirePoint();
    }

    public void SetShip(){
        
    }
}

