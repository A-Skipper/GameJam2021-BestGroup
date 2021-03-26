using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformmovement : MonoBehaviour
{
    private int speed = 50;
    
    private Rigidbody rb;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey(KeyCode.A)) {
            rb.velocity = 30;
            //transform.Rotate(Vector3.forward * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D)) { 
            //transform.Rotate(-Vector3.forward * speed * Time.deltaTime);
        }

    }
}
