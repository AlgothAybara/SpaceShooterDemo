using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCData : PlayerData
{
    public List<NPC_AI> AI_list;
    public NPC_AI currentAI;
    public int AI_index = 0;

    // public override void Start() {
    //     base.Start();
    //     currentAI = AI_list[AI_index];
    // }

    void UpdateFixed(){

    }
}
