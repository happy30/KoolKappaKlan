﻿using UnityEngine;
using System.Collections;

public class RotateScript : MonoBehaviour
{
    public float rotateSpeed;

	
	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
	}
}
