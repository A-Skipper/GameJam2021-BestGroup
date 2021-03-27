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
    public AudioClip mySound;
    private Monsterspawner monsterspawner;
    private Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        myParticles = GetComponent<ParticleSystem>();
        monsterspawner = GameObject.FindObjectOfType<Monsterspawner>().GetComponent<Monsterspawner>();
        timer = GameObject.FindObjectOfType<Timer>().GetComponent<Timer>();
    }


    void creatureHit(Collider2D creature)
    {

        //Do some fancy effects and play a sound or something. Based on the position where the creature hit us.
        myParticles.Play();
        playSound(mySound);
        Destroy(creature.transform.parent.gameObject);
        monsterspawner.monsterSpawned--;
        timer.TimerStart();

    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "creature")
        {
            if (targetType.ToString() == other.GetComponent<Creature>().creatureType.ToString())
            {
                manager.Invoke();
                manager.Invoke();
            }
            else
            {
                manager.Invoke();
            }


            creatureHit(other);
        }
    }




}
