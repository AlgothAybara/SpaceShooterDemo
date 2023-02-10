using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCombatController : CombatController
{

    // Start is called before the first frame update
    void Start(){
        nextShot = 0;
        SetFirePoint(gameObject);
        bulletPrefab = WeaponsList[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
