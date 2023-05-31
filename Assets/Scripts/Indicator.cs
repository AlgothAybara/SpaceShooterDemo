
using UnityEngine;

public class Indicator : MonoBehaviour
{
   public Transform Target;
   public float HideDistanceMin; //Hide arrow when approaching certain distance from object

    // Update is called once per frame
    protected virtual void Update()
    {
        var direction = Target.position - transform.position;
        
        //Have arrow visible while greater than min distance and less than max distance
        if (direction.magnitude < HideDistanceMin)
        {
            SetChildrenActive(false);
        }
        else
        {
            SetChildrenActive(true); 
        }
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }

    //This controls the visibility of the targeting arrows.
    protected void SetChildrenActive(bool value)
    {
         foreach (Transform child in transform)
            {
                child.gameObject.SetActive(value);
            }
    }
}
