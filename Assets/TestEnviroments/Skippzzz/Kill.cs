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
        if (other.transform.tag == "creature")
        {
            Destroy(other.transform.parent.gameObject);
            monsterspawner.monsterSpawned--;
        }
        
    }
}
