using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planetFadeIn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(fadeIn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    IEnumerator fadeIn()
    {
        while (this.GetComponent<SpriteRenderer>().color.a < 1)
        {
            Color objectColor = this.GetComponent<SpriteRenderer>().color;
            float fadeAmount = objectColor.a + (0.25f * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            this.GetComponent<SpriteRenderer>().color = objectColor;
            yield return null;
        }
    }
}
