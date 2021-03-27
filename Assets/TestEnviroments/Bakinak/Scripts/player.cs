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

    private Jail[] jails;
    private GameObject rightJail;
    private GameObject LeftJail;

    [SerializeField] private GameObject[] flames;

    private void Awake()
    {
        jails = FindObjectsOfType<Jail>();
        foreach (Jail i in jails)
        { 
            if (i.jailDir.ToString() == Jail.JailDir.Left.ToString())
            {
                LeftJail = i.gameObject;
            }
            else
            {
                rightJail = i.gameObject;
            }
            i.gameObject.SetActive(false);
        }
    }

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

            flames[0].SetActive(true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if(myrigidbody.angularVelocity < 0)
            {
                myrigidbody.angularVelocity *= -0.5f;
            }
            if (myrigidbody.angularVelocity < maxRotationSpeed) myrigidbody.AddTorque(force);

            flames[1].SetActive(true);
        }
        else
        {
            flames[0].SetActive(false);
            flames[1].SetActive(false);
        }



        //"Jail"
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (LeftJail.activeSelf == true)
            {
                LeftJail.SetActive(false);
            }
            else
            {
                LeftJail.SetActive(true);
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (rightJail.activeSelf == true)
            {
                rightJail.SetActive(false);
            }
            else
            {
                rightJail.SetActive(true);
            }
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

}
