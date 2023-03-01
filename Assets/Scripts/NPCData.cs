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
        if (updateState){
            currentAI = AI_list[AI_index];
            AI_index += 1;
        }
        // Debug.Log(this.currentAI);

    }

    // void Update(){
    //     currentAI = AI_list[AI_index];
    // }

    virtual public void OnTriggerEnter2D(Collider2D other){
        
        if (other.gameObject.tag == "Projectile"){
            target = other.gameObject.GetComponent<Projectile>().parent.gameObject;
            this.currentAI = aggresive;
            AI_index = 0;
        }
    }


    
}
