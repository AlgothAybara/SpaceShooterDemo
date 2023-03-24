using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCData : CharacterData
{
    float lerpSpeed;
    public CombatController combat;
    public MovementController2D movement;
    public Image shieldHealth;
    public Image integrityHealth;
    
    public int AI_index = 0;
    public GameObject target;

    public List<AI_NPC> AI_list;
    public AI_NPC currentAI;
    public AI_NPC aggresive;

    public override void Start() {
        base.Start();
        currentAI = AI_list[AI_index];    

    }

    void Update()
    {
        lerpSpeed = 5f * Time.deltaTime;
        ColorChanger();
        HealthBarFiller();
    }     
    void FixedUpdate(){
        bool updateState = this.currentAI.Execute(movement, combat, target);
        if (updateState && AI_index < AI_list.Count){
            currentAI = AI_list[AI_index];
            AI_index += 1;
        }
        else if (updateState && AI_index == AI_list.Count){
            Debug.Log(currentAI);
        }
        // Debug.Log(this.currentAI);
    }

    // void Update(){
    //     currentAI = AI_list[AI_index];
    // }

    virtual public void OnTriggerEnter2D(Collider2D other){
        
        if (other.gameObject.tag == "Projectile"
                && other.gameObject.GetComponent<Projectile>().parent != transform
                && currentShip.GetComponent<ShipClass>().shield.currentValue < currentShip.GetComponent<ShipClass>().shield.maxValue
            )
        {
            target = other.gameObject.GetComponent<Projectile>().parent.gameObject;
            this.currentAI = aggresive;
            AI_index = 0;
        }
    }
    void ColorChanger()
    {
        Color shieldHealthColor = Color.Lerp(Color.blue, Color.blue, (ship.shield.currentValue / ship.shield.maxValue));
        shieldHealth.color = shieldHealthColor;

        Color integrityHealthColor = Color.Lerp(Color.red, Color.green, (ship.integrity.currentValue / ship.integrity.maxValue));
        integrityHealth.color = integrityHealthColor;

    }

    void HealthBarFiller()
    {
        shieldHealth.fillAmount = Mathf.Lerp(shieldHealth.fillAmount, ship.shield.currentValue / ship.shield.maxValue, lerpSpeed);
        integrityHealth.fillAmount = Mathf.Lerp(integrityHealth.fillAmount, ship.integrity.currentValue / ship.integrity.maxValue, lerpSpeed);

    }
    


    
}
