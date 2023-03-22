using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteSelect : MonoBehaviour
{
    // Biased select of items in a tuple list.
    public object Select(List<(object, int)> Tlist){
        var max = Sum(Tlist);
        var guess = Random.Range(0, max);
        foreach(var tuple in Tlist){
            if (guess <= tuple.Item2){
                return tuple.Item1;
            }
        }
        return Tlist[0].Item1;
    }

    // iterates through tuple list to calculate max of list
    private int Sum(List<(object, int)> Tlist){
        var sum = 0;
        foreach (var tuple in Tlist){
            sum += tuple.Item2;
        }
        return sum;
    }
}
