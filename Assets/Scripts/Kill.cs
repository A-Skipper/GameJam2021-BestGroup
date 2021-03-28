using UnityEngine.Events;
using UnityEngine;

public class Kill : SoundClass
{
    [SerializeField] private  AudioClip mySound;
    private Monsterspawner monsterspawner;

    private void Awake()
    {
        monsterspawner = GameObject.FindObjectOfType<Monsterspawner>().GetComponent<Monsterspawner>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "creature")
        {
            playSound(mySound);
            Destroy(other.transform.parent.gameObject);
            monsterspawner.monsterSpawned--;
        }
        
    }
}
