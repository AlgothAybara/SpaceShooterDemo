using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    public GameObject test;
    public Dictionary<GameObject, int> inventory;

    virtual public void DisplayData(GameObject key){
        string outlog = string.Format($"Key: {0}, Value: {1}", key, inventory[key]);
        Debug.Log(outlog);
    }

    virtual public int GetCount(GameObject key){
        return inventory[key];
    }

    virtual public bool UpdateCount(GameObject key, int num){
        if (GetCount(key) + num < 0){
            return false;
        }
        else {
            inventory[key] += num;
            return true;
        }
    }
}