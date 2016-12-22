//Made by Arne
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartShuriken : MonoBehaviour {

    public int shurikenCount;
    public bool throwShuriken;

    public float shurikenSpeed;
    public GameObject shurikenObject;

    public float nextShot = 0.0f;
    public float interval = 0.8f;


    public float moveForce = 1.0F;
    public float rotateTorque = 1.0F;
    public float hoverHeight = 4.0F;
    public float hoverForce = 5.0F;
    public float hoverDamp = 0.5F;
    public Rigidbody rb;


    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        rb.drag = 0.5F;
        rb.angularDrag = 0.5F;
    }
	// Update is called once per frame
	void FixedUpdate () {
        Move();
        ShurikenAttack();
	}
    public void Move()
    {
        /*rb.AddForce(Input.GetAxis("Vertical") * moveForce * transform.forward);
        rb.AddTorque(Input.GetAxis("Horizontal") * rotateTorque * Vector3.up);
        RaycastHit hit;
        Ray downRay = new Ray(transform.position, -Vector3.up);
        if (Physics.Raycast(downRay, out hit))
        {
            float hoverError = hoverHeight - hit.distance;
            if (hoverError > 0)
            {
                float upwardSpeed = rb.velocity.y;
                float lift = hoverError * hoverForce - upwardSpeed * hoverDamp;
                rb.AddForce(lift * Vector3.up);
            }
        }*/
    }
    public void ShurikenAttack ()
    {
        if (Input.GetKey(InputManager.Shuriken))
        {
            if(shurikenCount <= 0)
            {
                print("cant touch this");
            }
            else
            {
                if (Time.time >= nextShot)
                {
                    nextShot = Time.time + interval;
                    GameObject clone;
                    clone = Instantiate(shurikenObject, transform.position + (transform.forward * 2), transform.rotation);
                    clone.GetComponent<Rigidbody>().AddForce(clone.transform.forward * shurikenSpeed);
                    shurikenCount = shurikenCount - 1;
                }
            }
        }
    }
}
/*if (throwShuriken == false)
            {
                GameObject clone;
                clone = Instantiate(shurikenObject, transform.position, transform.rotation);
                clone.rigidbody.AddForce(clone.transform.forward * shurikenSpeed);
                shurikenCount = shurikenCount - 1;
                throwShuriken = true;
            }
            else if (throwShuriken = true)
            {
                if (shurikenCount <= 0)
                {
                    //empty item box
                    print("cant touch this");
                }
                else
                {
                   throwShuriken = false;
                }
            }
            */
