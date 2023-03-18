using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageIndicator : MonoBehaviour
{
    Transform damagePopUp;

    private TextMeshPro textMesh;
    private Color textColor;
    float disappearTime;
    [SerializeField] private Transform damageIndicator;
    
    public void Create(Vector3 position, float damage)
    {
        damagePopUp = Instantiate(damageIndicator, position, Quaternion.identity);
        DamageIndicator damageText = damagePopUp.GetComponent<DamageIndicator>();
        damageText.Setup(damage);
    }
    
    private void Start()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
        
    }

    public void Setup(float damage)
    {
        textMesh.SetText(damage.ToString());
        disappearTime = 1f;
        textColor = textMesh.color;
    }

    void Update()
    {
        float moveYSpeed = 5f;
        transform.position += new Vector3(0, moveYSpeed) * Time.deltaTime;

        disappearTime -= Time.deltaTime;
        if (disappearTime < 0)
        {
            float disappearSpeed = 5f;
            textColor.a -= disappearSpeed * Time.deltaTime;
            textMesh.color = textColor;
            if (textColor.a < 0)
            {
                Destroy(gameObject);
            }
        }

    }
}
