using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetsS : MonoBehaviour
{

    [SerializeField]
    public GameObject[] Planets;
    public bool test = false;


    int ran;



    float timer = 5;
    bool isSpawn = true;
    GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        ran = Random.Range(0, 3);
        timer -= Time.deltaTime;

        if (timer > 0)
        {
            if (isSpawn)
            {
                obj = Instantiate(Planets[ran], gameObject.transform.position, Quaternion.identity);
                isSpawn = false;
            }

            obj.transform.position -= new Vector3(0, 0, 0.1f);
        }
        else
        {
            isSpawn = true;
            timer = 5;
            Destroy(obj);
        }
        

    }

}





 
