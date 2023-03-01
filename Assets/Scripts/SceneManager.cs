using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public List<GameObject> spawnableShips;
    public List<GameObject> spawnedNPCs;
    public List<GameObject> Planets;
    public  int maxDist = 100;
    public int maxStartCount = 12;
    public int maxSceneCount = 24;
    private int[] spawnState = {1,2};

    // Start is called before the first frame update
    void Start()
    {
        int spawnCount = Random.Range(0, maxStartCount);
        for (int i = 0; i < spawnCount; i++){
            var i1 = Random.Range(0, spawnableShips.Count);
            var ship = spawnableShips[i1];
            var state = spawnState[Random.Range(0, spawnState.Length)];
            var planet = Planets[Random.Range(0, Planets.Count)];
            var NPC = Instantiate(ship, 
                        RandomLocation(), 
                        ship.transform.rotation,
                        gameObject.transform);
            Debug.Log(NPC.GetComponent<NPCData>());
            NPC.GetComponent<NPCData>().AI_index = state;
            NPC.GetComponent<NPCData>().target = planet;
            spawnedNPCs.Add(NPC);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 RandomLocation(){
        return Random.insideUnitCircle * maxDist;
    }
}
