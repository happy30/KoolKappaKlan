//Made by Arne
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartCamera : MonoBehaviour {

	public Transform camTransform;
	public Transform kartNumber;
	
	private Camera cam;
	
	private float distance = 10f;
	private float currentX = 0.0f;
	private float currentY = 0.0f;
	private float height = 5f;
	
	private float sensitivityX = 4.0f;
	private float sensitivityY = 1.0f;
	//private float followSpeed = 45f;
	
	
	// Use this for initialization
	private void Start () 
	{
		camTransform = transform;
		cam = Camera.main;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		FollowKart();
	}
	/*public void LateUpdate () 
	{
		Vector3 dir = new Vector3(0,0,-distance);
		Quaternion rotation = Quaternion.Euler(currentX,currentY,0);
		camTransform.position = kartNumber.position + rotation * dir;
		camTransform.LookAt(kartNumber.position);
	}*/
	public void FollowKart () 
	{
		camTransform.LookAt(kartNumber);
		
	}
}
