using System;
using UnityEngine;

public class Kill : MonoBehaviour
{
    private Monsterspawner monsterspawner;

    private void Awake()
    {
        monsterspawner = GameObject.FindObjectOfType<Monsterspawner>().GetComponent<Monsterspawner>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        try
        {
            //Either center or outer colider of object can hit
            if (other.gameObject.transform.parent.gameObject.transform.parent.gameObject != null)
            {
                Destroy(other.gameObject.transform.parent.gameObject.transform.parent.gameObject);
                monsterspawner.monsterSpawned--;
            }
            else
            {
                Destroy(other.gameObject.transform.parent.gameObject);
                monsterspawner.monsterSpawned--;
            }
        }
        catch (NullReferenceException)
        {
            //Nothing need to happen if the gameobject is already destoryed
            //Debug.Log("Object already destroyed");
        }
        
    }
}
