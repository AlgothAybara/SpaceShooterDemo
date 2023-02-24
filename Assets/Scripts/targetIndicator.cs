
using UnityEngine;

public class targetIndicator : MonoBehaviour
{
   public Transform Target;
   public float HideDistance;


    // Update is called once per frame
    void Update()
    {
        var direction = Target.position - transform.position;
        
        if (direction.magnitude < HideDistance)
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

    void SetChildrenActive(bool value)
    {
         foreach (Transform child in transform)
            {
                child.gameObject.SetActive(value);
            }
    }
}
