using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        if (gameObject.transform.position.z >= -10f)
        {
            Destroy(gameObject);
        }
    }
}
