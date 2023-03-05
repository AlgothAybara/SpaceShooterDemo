// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class SystemManager : MonoBehaviour
// {
//     public List<GameObject> spawnableShips;
//     public List<GameObject> spawnedNPCs;
//     public List<GameObject> Planets;
//     public  int maxDist = 100;
//     public int maxStartCount = 12;
//     public int maxSceneCount = 24;
//     public int chance = 1000;
//     public int currentChance;
//     private int[] spawnState = {0,2};

//     // Start is called before the first frame update
//     void Start()
//     {
//         currentChance = Random.Range(0, chance);
//         int spawnCount = Random.Range(0, maxStartCount);
//         for (int i = 0; i < spawnCount; i++){
//             SpawnNPC(RandomLocation(), spawnState[Random.Range(0, spawnState.Length)]);
//         }
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }

//     void FixedUpdate() {
//         spawnedNPCs.RemoveAll(it => it == null);
//         if (spawnedNPCs.Count < maxSceneCount)
//         {
//             AttemptSpawn();
//         }
//     }

//     private Vector3 RandomLocation(){
//         return Random.insideUnitCircle * maxDist;
//     }

//     private void AttemptSpawn(){
//         int guess = Random.Range(0, chance);
//         // int currentChance = Random.Range(0, chance);
//         if (guess == currentChance)
//         {
//             currentChance = Random.Range(0, chance);
//             SpawnNPC(RandomLocation().normalized * maxDist, 0);
//         } 

//     }

//     private void SpawnNPC(Vector3 location, int state){
//         var ship = spawnableShips[Random.Range(0, spawnableShips.Count)];
//         var planet = Planets[Random.Range(0, Planets.Count)];
//         var NPC = Instantiate(ship, 
//                     location, 
//                     ship.transform.rotation,
//                     gameObject.transform);
//         // Debug.Log(NPC.GetComponent<NPCData>());
//         NPC.GetComponent<NPCData>().AI_index = state;
//         NPC.GetComponent<NPCData>().target = planet;
//         spawnedNPCs.Add(NPC);
//     }
// }
