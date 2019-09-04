using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float turnSpeed;
    
    private Rigidbody rb;

    public float rayLength;
    private RaycastHit objectHit;
    private GameObject curObj;

    public float gravityStrenght;
    public float jumpStrength;
    public float canJump;
    public float brakeSpeed = 0.0f;
    public float acceleration = 0.25f;
    public float maxSpeed = 1.5f;
    public float stopSpeed = 0.0f;
    private float curSpeed = 0.0f;

    public ParticleSystem moveParticles;
    public ParticleSystem brakeParticlesA;
    public ParticleSystem brakeParticlesB;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, -gravityStrenght, 0);
    }

    // Update is called once per frame
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            canJump = 0;
            jumpStrength = 30000;
        }
        if (collision.gameObject.tag == "Ramp")
        {
            canJump = 0;
            jumpStrength = 40000;
        }
        if (collision.gameObject.tag == "RampSweetSpot")
            {
                canJump = 0;
                jumpStrength = 90000;
            }
        if (collision.gameObject.tag == "Wall")
        {
            curSpeed -= 50.0f * Time.deltaTime;
        }
        if (curSpeed < stopSpeed)
        {
            curSpeed = 0;
        }
    }
    void Update() {
        print(curSpeed);
        
        Debug.DrawRay(transform.position, -transform.up * rayLength, Color.red);       
        if (Physics.Raycast(transform.position, -transform.up, out objectHit, rayLength))
        {
            if (curObj != objectHit.collider.gameObject)
            {
                print("I hit: " + objectHit.transform.name);
                canJump = 0;
            }
            else
            {
               if (curObj != null)
                {
                   print("I hit Nothing");
                   canJump = 1;
                }
               
           }
        }
        //if (Input.GetKey(KeyCode.Space))
        {
        //    curSpeed -= brakeSpeed * Time.deltaTime;
           // if (curSpeed < stopSpeed)
        {
           // curSpeed = 0;
        }
            if (Input.GetButton("Brake"))
            {
                curSpeed -= brakeSpeed * Time.deltaTime;
                turnSpeed = 2;
                if (curSpeed < stopSpeed)
                  {
                    curSpeed = 1.75f;
                  }
            }
            if (Input.GetButtonDown("Brake") && curSpeed >= 0.0f)
            {
                moveParticles.Stop();
                brakeParticlesA.Play();
                brakeParticlesB.Play();
            }
            else
            if (Input.GetButton("Brake") && curSpeed <= 0.0f)
            {
                moveParticles.Stop();
                brakeParticlesA.Stop();
                brakeParticlesB.Stop();
            }
            if (Input.GetButtonUp("Brake"))
            {
                turnSpeed = 0.75f;
                moveParticles.Play();
                brakeParticlesA.Stop();
                brakeParticlesB.Stop();
            }
            if (Input.GetButtonUp("Jump") && canJump == 0)
            {
                rb.AddForce(transform.up * jumpStrength * Time.deltaTime);
                canJump = 1;
            }
            //curSpeed = 0.0f;
            //transform.Translate(0, 0, -1 * curSpeed);
        }

    }
    void FixedUpdate()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        transform.Rotate(0, x * turnSpeed, 0);
        //rb.AddForce(transform.forward * curSpeed * Time.deltaTime);
        transform.Translate(Vector3.forward * curSpeed * Time.deltaTime);
        curSpeed += acceleration * Time.deltaTime;

        if (curSpeed > maxSpeed)
        {
            curSpeed = maxSpeed;
        }
    }
    }
