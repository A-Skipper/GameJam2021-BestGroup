using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monsterspawner : MonoBehaviour
{
    public Transform[] spawnpoints;
    public GameObject[] monsters;
    int randomSpawnPoint, randomMonster, monsterSpawned = 0;
    public int level, spawnRate = 5;
    public static bool spawnAllowed;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnAllowed = true;
        InvokeRepeating("SpawnAMonster", 1f, spawnRate);
        
    }


    void SpawnAMonster()
    {
        if (spawnAllowed)
        {
            randomSpawnPoint = Random.Range(0, spawnpoints.Length);
            randomMonster = Random.Range(0, monsters.Length);
            Instantiate(monsters[randomMonster], spawnpoints[randomSpawnPoint].position, Quaternion.identity);
            monsterSpawned = monsterSpawned + 1;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (monsterSpawned > level)
        {
            spawnAllowed = false;
        }
        else
        {
            spawnAllowed = true;
        }
    }
}
