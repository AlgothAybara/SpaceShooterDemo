using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_NPC : MonoBehaviour
{
    public GameObject target;

    public virtual bool Execute(MovementController2D movement, CombatController combat, GameObject target){
        Move(movement, target);
        Attack(combat, target);
        return false;
    }

    virtual public void Move(MovementController2D movement, GameObject target){

    }

    virtual public void Attack(CombatController combat, GameObject target){

    }

}
