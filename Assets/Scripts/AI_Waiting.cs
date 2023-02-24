using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Waiting : AI_NPC
{
    public float wait = 0;

    public override bool Execute(MovementController2D movement, CombatController combat, GameObject target){
        if (wait == 0) {
            wait = Time.time + Random.Range(5,10);
        } else if (Time.time > wait){
            return true;
        }
        return false;
    }
}