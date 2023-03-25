using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCombatController : CombatController
{
   

    // Start is called before the first frame update
    public override void Start(){
        base.Start();
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
