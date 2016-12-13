//Made by Arne
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartShuriken : MonoBehaviour {

    public int shurikenCount;

    public GameObject shurikenObject;
	// Use this for initialization
	void Start () {
		
	}
	// Update is called once per frame
	void FixedUpdate () {
        Move();
        if(Input.GetKey(InputManager.Shuriken))
        {
            
        }
	}
    public void Move ()
    {

    }
}
