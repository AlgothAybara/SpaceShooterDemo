using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCombatController : CombatController
{

    // Start is called before the first frame update
    void Start(){
        nextShot = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(firePoint==null){
            SetFirePoint(gameObject);
        }
        if(bulletPrefab==null){
            bulletPrefab = WeaponsList[0];
        }
    }
}
