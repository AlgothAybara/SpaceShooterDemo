using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_AI : MonoBehaviour
{

    public void Execute(MovementController2D movement, CombatController combat, GameObject target){
        Move(movement, target);
        Attack(combat, target);
    }

    virtual public void Move(MovementController2D movement, GameObject target){

    }

    virtual public void Attack(CombatController combat, GameObject target){

    }

}
