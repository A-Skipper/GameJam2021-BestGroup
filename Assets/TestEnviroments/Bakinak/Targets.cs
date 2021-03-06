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

    // Start is called before the first frame update
    void Start()
    {
        myParticles = GetComponent<ParticleSystem>();
    }


    void creatureHit(Collider2D creature)
    {

        //Do some fancy effects and play a sound or something. Based on the position where the creature hit us.
        myParticles.Play();
        playSound(mySound);
        Destroy(creature.gameObject);
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
