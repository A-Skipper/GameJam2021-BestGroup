using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundEffect : MonoBehaviour
{
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        clip = GetComponent<AudioSource>().clip;
        Destroy(gameObject, clip.length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
