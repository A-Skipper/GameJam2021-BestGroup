using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class squeakOnImpact : SoundClass
{
    public AudioClip[] squeaks;
    public float impactLimit = 8;
    bool squeakable = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "ship" || collision.transform.tag == "creature")
        {
            //Maybe check the angular velocity of the ship or something as well?
            if (GetComponent<Rigidbody2D>().velocity.magnitude > impactLimit && squeakable)
            {
                squeakable = false;
                StartCoroutine(ExecuteAfterTime(5));
                int clip = Random.Range(0, squeaks.Length);
                playSound(squeaks[clip]);
            }
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        squeakable = true;
    }
}
