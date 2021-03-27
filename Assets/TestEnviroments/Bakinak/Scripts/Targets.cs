using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Targets : SoundClass
{
    public enum TargetType { Red, blue };
    public TargetType targetType;
    [SerializeField] UnityEvent manager = default;

    ParticleSystem myParticles;
    public AudioClip correctSound;
    public AudioClip wrongSound;
    private Monsterspawner monsterspawner;
    // Start is called before the first frame update
    void Start()
    {
        myParticles = GetComponent<ParticleSystem>();
        monsterspawner = GameObject.FindObjectOfType<Monsterspawner>().GetComponent<Monsterspawner>();
    }


    void creatureHit(Collider2D creature)
    {
        //Do some fancy effects and play a sound or something. Based on the position where the creature hit us.
        myParticles.Play();
        Destroy(creature.transform.parent.gameObject);
        monsterspawner.monsterSpawned--;
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "creature")
        {
            if (targetType.ToString() == other.GetComponent<Creature>().creatureType.ToString())
            {
                playSound(correctSound);
                manager.Invoke();
                manager.Invoke();
            }
            else
            {
                playSound(wrongSound);
                manager.Invoke();
            }


            creatureHit(other);
        }
    }




}
