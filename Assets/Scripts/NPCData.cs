using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCData : CharacterData
{
    public CombatController combat;
    public MovementController2D movement;
    public List<NPC_AI> AI_list;
    public NPC_AI currentAI;
    public int AI_index = 0;
    public GameObject target;

    public override void Start() {
        base.Start();
        currentAI = AI_list[AI_index];
    }

    void FixedUpdate(){
        currentAI.Execute(movement, combat, target);
    }



    
}
