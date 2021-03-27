using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monsterspawner : MonoBehaviour
{
    public Transform[] spawnpoints;
    public GameObject[] monsters;
    int randomSpawnPoint, randomMonster;
    private int level, spawnRate = 1;
    public static bool spawnAllowed;
    public int monsterSpawned;
    private Timer timer;
    private float time;
    private bool startet;

    // Start is called before the first frame update
    void Start()
    {
        
        spawnAllowed = true;
        InvokeRepeating("SpawnAMonster", 1f, spawnRate);
        timer = GameObject.FindObjectOfType<Timer>().GetComponent<Timer>();
        
    }


    void SpawnAMonster()
    {
        if (spawnAllowed)
        {
            randomSpawnPoint = Random.Range(0, spawnpoints.Length);
            randomMonster = Random.Range(0, monsters.Length);
            Instantiate(monsters[randomMonster], spawnpoints[randomSpawnPoint].position, Quaternion.identity);
            monsterSpawned++;
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        //spawnRate = Random.Range(0, 5);
        startet = timer.StartTimer;
        time += Time.deltaTime;
        if (startet)
        {

            if (time >= 5)
            {
                
                level = level + 1;
                time = 0;
            }
            
        }

        
        
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
