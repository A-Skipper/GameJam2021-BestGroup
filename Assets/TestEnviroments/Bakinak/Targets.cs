using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Targets : MonoBehaviour
{

    [SerializeField] UnityEvent manager = default;

    ParticleSystem myParticles;

    // Start is called before the first frame update
    void Start()
    {
        myParticles = GetComponent<ParticleSystem>();
    }


    void creatureHit(Collider creature)
    {

        //Do some fancy effects and play a sound or something. Based on the position where the creature hit us.
        myParticles.Play();

        Destroy(creature.gameObject);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "creature")
        {
            manager.Invoke();
            creatureHit(other);
        }
    }




}
