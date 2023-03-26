using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemManager : MonoBehaviour
{

    public List<GameObject> spawnableShips;
    public List<GameObject> spawnedNPCs;
    public List<GameObject> Planets;
    public List<int> PlanetBias;
    public GameObject NPCPrefab;
    public  int maxDist = 100;
    public int maxStartCount = 12;
    public int maxSceneCount = 24;
    public int chance = 1000;
    public int currentChance;
    private int[] spawnState = {0,2};
    private RouletteSelect Rselect;
    public float TS;

    // Start is called before the first frame update
    void Start()
    {
        Rselect = new RouletteSelect();
        currentChance = Random.Range(0, chance);
        int spawnCount = Random.Range(0, maxStartCount);
        for (int i = 0; i < spawnCount; i++){
            SpawnNPC(RandomLocation(), spawnState[Random.Range(0, spawnState.Length)]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Time.timeScale = TS;
    }

    void FixedUpdate() {
        spawnedNPCs.RemoveAll(it => it == null);
        if (spawnedNPCs.Count < maxSceneCount)
        {
            AttemptSpawn();
        }
    }

    private Vector3 RandomLocation(){
        return Random.insideUnitCircle * maxDist;
    }

    private void AttemptSpawn(){
        int guess = Random.Range(0, chance);
        // int currentChance = Random.Range(0, chance);
        if (guess == currentChance && Time.timeScale != 0f)
        {
            currentChance = Random.Range(0, chance);
            SpawnNPC(RandomLocation().normalized * maxDist, 0);
        } 

    }

    private void SpawnNPC(Vector3 location, int state){
        var ship = spawnableShips[Random.Range(0, spawnableShips.Count)];
        var planet = Rselect.Select(Planets, PlanetBias);
        var NPC = Instantiate(NPCPrefab, 
                    location, 
                    ship.transform.rotation,
                    gameObject.transform.GetChild(2));
        NPC.GetComponent<NPCData>().Ship = ship;
        NPC.GetComponent<NPCData>().AI_index = state;
        NPC.GetComponent<NPCData>().target = planet;
        spawnedNPCs.Add(NPC);
        spawnedNPCs.RemoveAll(item => item == null);
    }
}
