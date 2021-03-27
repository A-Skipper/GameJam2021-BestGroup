using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class player : MonoBehaviour
{

    //Handbrake and booster too, if I can.
    //Handbrake: Check whether angular velocity is positive or negative. If positive and handbrake is pulled, apply force to all creatures in the corresponding side of the platform. If negative, other side.
    //Boost: Hold boost to have faster rotation. Stop holding for more precise movement.

    //Make platform go towards default position when not pressing a button.

    Rigidbody2D myrigidbody;
    float force = 1;
    float maxRotationSpeed;
    Collider2D[] creaturesToPropulse1, creaturesToPropulse2;

    /*public LayerMask creatureLayer;
    public Transform propZoneLeft, propZoneRight, propZone11, propZone12, propZone21, propZone22;*/

    [SerializeField] float propulsionStrength;
    [SerializeField] float slowDownRotation = 0.99f;
    [SerializeField] float slowForce = 1;
    [SerializeField] float fastForce = 2;
    [SerializeField] float slowMaxRotationSpeed = 250;
    [SerializeField] float fastMaxRotationSpeed = 400;
    //[SerializeField] float returnToDefaultSpeedScalar = 1;



    //Start is called before the first frame update
    void Start()
    {
        myrigidbody = GetComponent<Rigidbody2D>();
        force = slowForce;
        maxRotationSpeed = slowMaxRotationSpeed;
    }
    
    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            creaturesToPropulse1 = Physics2D.OverlapAreaAll(propZone11.position, propZone12.position, creatureLayer);
            creaturesToPropulse2 = Physics2D.OverlapAreaAll(propZone21.position, propZone22.position, creatureLayer);

            applyPropulsion();
        }*/

        //Check if boosting? This might be buggy as shit, who knows.
        if (Input.GetKeyDown(KeyCode.LeftShift)){
            force = fastForce;
            maxRotationSpeed = fastMaxRotationSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            force = slowForce;
            maxRotationSpeed = slowMaxRotationSpeed;
        }




        if (Input.GetKey(KeyCode.D)){
            if (myrigidbody.angularVelocity > 0)
            {
                //If you want to change rotation direction, keep part of the momentum you already had.
                myrigidbody.angularVelocity *= -0.5f;
            }
            if (myrigidbody.angularVelocity > maxRotationSpeed * -1) myrigidbody.AddTorque(-force);

        }
        else if (Input.GetKey(KeyCode.A))
        {
            if(myrigidbody.angularVelocity < 0)
            {
                myrigidbody.angularVelocity *= -0.5f;
            }
            if (myrigidbody.angularVelocity < maxRotationSpeed) myrigidbody.AddTorque(force);

        }

        else
        {
            //Reset automatically to default position if uncommented
            /*
            if(transform.rotation.z > 0) myrigidbody.angularVelocity -= transform.rotation.z * returnToDefaultSpeedScalar;
            else if(transform.rotation.z < 0) myrigidbody.angularVelocity -= transform.rotation.z * returnToDefaultSpeedScalar;
            */
            myrigidbody.angularVelocity *= slowDownRotation;
        }
    }


    //fuck all this
    /*
    void applyPropulsion()
    {
        for(int i = 0; i < creaturesToPropulse1.Length; i++)
        {
            Debug.Log("left");
            //Apply force, should depend on angle too though.
            creaturesToPropulse1[i].GetComponent<Rigidbody2D>().AddForce(propZoneLeft.up * propulsionStrength, ForceMode2D.Impulse);
            //creaturesToPropulse1[i].GetComponent<Rigidbody2D>().velocity += new Vector2(0, 100);

        }
        //Do for other array as well.
        for (int i = 0; i < creaturesToPropulse2.Length; i++)
        {
            Debug.Log("right");
            //Apply force, should depend on angle too though.
            creaturesToPropulse2[i].GetComponent<Rigidbody2D>().AddForce(propZoneRight.forward * propulsionStrength);
        }

    }
    */
}
