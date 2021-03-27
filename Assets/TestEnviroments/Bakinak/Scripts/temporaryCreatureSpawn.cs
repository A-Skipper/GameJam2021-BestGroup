using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temporaryCreatureSpawn : MonoBehaviour
{

    public Transform spawnPlace;

    // Start is called before the first frame update
    void Start()
    {
        
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "creature")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            collision.transform.position = spawnPlace.position;
        }
    }

}
