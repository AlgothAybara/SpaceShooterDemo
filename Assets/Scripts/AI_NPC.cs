using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_NPC : MonoBehaviour
{

    public float last_distance = 0;
    public GameObject target;

    public virtual void Execute(MovementController2D movement, CombatController combat, GameObject target){
        Move(movement, target);
        Attack(combat, target);
    }

    virtual public void Move(MovementController2D movement, GameObject target){

    }

    virtual public void Attack(CombatController combat, GameObject target){

    }

}