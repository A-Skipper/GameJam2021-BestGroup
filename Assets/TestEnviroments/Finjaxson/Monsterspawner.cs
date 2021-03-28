using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monsterspawner : MonoBehaviour
{
    public Transform[] spawnpoints;
    public GameObject[] monsters;
    int randomSpawnPoint, randomMonster;

    public float[] spawnRates;
    int currentSpawnRate;
    public float spawnIncreaseFrequency = 20;
    private float roundTime;

    private int level;
    public static bool spawnAllowed;
    public int monsterSpawned;
    private Timer timer;
    private float time;

    private bool startet;

    // Start is called before the first frame update
    void Start()
    {
        
        spawnAllowed = true;
        InvokeRepeating("SpawnAMonster", 1f, spawnRates[currentSpawnRate]);
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
        roundTime += Time.deltaTime;
        if (startet)
        {

            if (time >= 10)
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


        if(roundTime >= spawnIncreaseFrequency)
        {
            CancelInvoke();
            roundTime = 0;
            if(currentSpawnRate < spawnRates.Length-1) currentSpawnRate += 1;
            InvokeRepeating("SpawnAMonster", 1f, spawnRates[currentSpawnRate]);
        }

    }
}
