//Made by Arne
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartShuriken : MonoBehaviour {

    public int shurikenCount;

    public float shurikenSpeed;
    public GameObject shurikenObject;

	// Use this for initialization
	void Start () {
		
	}
	// Update is called once per frame
	void FixedUpdate () {
        Move();
        ShurikenAttack();
	}
    public void Move ()
    {

    }
    public void ShurikenAttack ()
    {
        if (Input.GetKey(InputManager.Shuriken))
        {
            GameObject clone;
            clone = Instantiate(shurikenObject, transform.position, transform.rotation);
            //clone.GetComponent.rigidbody.AddForce(clone.transform.forward * shurikenSpeed);
        }
    }
}
