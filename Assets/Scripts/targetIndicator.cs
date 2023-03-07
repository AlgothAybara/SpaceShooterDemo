
using UnityEngine;

public class targetIndicator : MonoBehaviour
{
   public Transform Target;
   public float HideDistanceMin; //Hide arrow when approaching certain distance from object
   public float HideDistanceMax; //Hide arrow when x distance from object

    // Update is called once per frame
    void Update()
    {
        try {
            Target = this.GetComponentInParent<PlayerCombatController>().Target.transform;
            Debug.Log(Target.name);
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
      
        var direction = Target.position - transform.position;
        
        //Have arrow visible while greater than min distance and less than max distance
        if (direction.magnitude < HideDistanceMin)
        {
            SetChildrenActive(false);
        }
        // else if (direction.magnitude > HideDistanceMax)
        // {
        //     SetChildrenActive(false);
        // }
        else
        {
            SetChildrenActive(true); 
        }
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    //This controls the visibility of the targeting arrows.
    void SetChildrenActive(bool value)
    {
         foreach (Transform child in transform)
            {
                child.gameObject.SetActive(value);
            }
    }
}
