using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteSelect : MonoBehaviour
{
    // Biased select of items in a tuple list.
    public GameObject Select(List<GameObject> Plist, List<int> Ilist){
        // var max = Sum(Ilist);
        var max = 100;
        var guess = Random.Range(0, max);
        var select = 0;
        for(var i = 0; i < Ilist.Count; i++){
            if (guess <= Ilist[i]){
                select = i;
                Debug.Log(max + " " + guess + " " + select);
                break;
            }
        }
        return Plist[select];
    }

    // iterates through tuple list to calculate max of list
    private int Sum(List<int> Ilist){
        var sum = 0;
        foreach (var num in Ilist){
            sum += num;
        }
        return sum;
    }
}
