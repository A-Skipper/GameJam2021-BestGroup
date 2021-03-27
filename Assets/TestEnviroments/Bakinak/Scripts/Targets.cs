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
    public AudioClip CorrectSound;
    public AudioClip WrongSound;
    private Monsterspawner monsterspawner;
    // Start is called before the first frame update

    public int startHitpoint = 10;
    int currentHitpoint;
    public float respawnTime = 15;
    public float fadeSpeed = 5;
    private bool fading = true;

    void Start()
    {
        myParticles = GetComponent<ParticleSystem>();
        monsterspawner = GameObject.FindObjectOfType<Monsterspawner>().GetComponent<Monsterspawner>();
        currentHitpoint = startHitpoint;
    }


    void creatureHit(Collider2D creature)
    {

        //Do some fancy effects and play a sound or something. Based on the position where the creature hit us.
        myParticles.Play();
        Destroy(creature.transform.parent.gameObject);
        monsterspawner.monsterSpawned--;

        updatehitpoint();
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "creature")
        {
            if (targetType.ToString() == other.GetComponent<Creature>().creatureType.ToString())
            {
                playSound(CorrectSound);
                manager.Invoke();
                manager.Invoke();
            }
            else
            {
                playSound(WrongSound);
                manager.Invoke();
            }


            creatureHit(other);
        }
    }

    void updatehitpoint()
    {
        currentHitpoint -= 1;

        if(currentHitpoint <= 0)
        {
            if (fading == true)
            {
                fading = false;
                StartCoroutine(fadeOut());
            }
        }
    }


    IEnumerator fadeOut()
    {
        while(this.GetComponent<SpriteRenderer>().color.a > 0)
        {
            Color objectColor = this.GetComponent<SpriteRenderer>().color;
            float fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            this.GetComponent<SpriteRenderer>().color = objectColor;
            if (this.GetComponent<SpriteRenderer>().color.a <= 0)
            {
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<SpriteRenderer>().enabled = false;
                StartCoroutine(ExecuteAfterTime(respawnTime));
            }
            yield return null;
        }

    }


    IEnumerator fadeIn()
    {
        while (this.GetComponent<SpriteRenderer>().color.a < 1)
        {
            Color objectColor = this.GetComponent<SpriteRenderer>().color;
            float fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            this.GetComponent<SpriteRenderer>().color = objectColor;
            yield return null;
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(fadeIn());
        // Code to execute after the delay
        currentHitpoint = startHitpoint;
        GetComponent<BoxCollider2D>().enabled = true;
        GetComponent<SpriteRenderer>().enabled = true;
        fading = true;

    }

}
