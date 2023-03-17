using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCData : CharacterData
{
    public CombatController combat;
    public MovementController2D movement;
    
    public int AI_index = 0;
    public GameObject target;

    public List<AI_NPC> AI_list;
    public AI_NPC currentAI;
    public AI_NPC aggresive;

    public override void Start() {
        base.Start();
        currentAI = AI_list[AI_index];
    }

    void FixedUpdate(){
        bool updateState = this.currentAI.Execute(movement, combat, target);
        if (updateState && AI_index < AI_list.Count){
            currentAI = AI_list[AI_index];
            AI_index += 1;
        }
        else if (updateState && AI_index == AI_list.Count){
            Debug.Log(currentAI);
        }
        // Debug.Log(this.currentAI);
    }

    // void Update(){
    //     currentAI = AI_list[AI_index];
    // }

    virtual public void OnTriggerEnter2D(Collider2D other){
        
        if (other.gameObject.tag == "Projectile" 
                && other.gameObject.GetComponent<Projectile>().parent != transform
                && currentShip.GetComponent<ShipClass>().shield.currentValue < currentShip.GetComponent<ShipClass>().shield.maxValue
            )
        {
            target = other.gameObject.GetComponent<Projectile>().parent.gameObject;
            this.currentAI = aggresive;
            AI_index = 0;
        }
    }


    
}
