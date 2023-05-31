
using UnityEngine;

public class NPCIndicator : Indicator
{
    // Update is called once per frame
    protected override void Update()
    {
        try {
            Target = this.GetComponentInParent<PlayerCombatController>().Target.transform;
            if (Target.name == "EmptyTarget"){
                SetChildrenActive(false);
                return;
            }
            else {
                SetChildrenActive(true);
            }
        }
        //If target doesn't exist, don't have the arrow appear
        catch {
            SetChildrenActive(false);
            return;
        }
      
        base.Update();
    }
}
