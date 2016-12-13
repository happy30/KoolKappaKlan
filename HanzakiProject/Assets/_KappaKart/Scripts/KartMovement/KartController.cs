//Made by Faf
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartController : MonoBehaviour
{
    public enum ItemType { None, Shuriken, Bomb, Hook, Katana, Box}
    public ItemType heldItem;

    public bool raceStarted;
    public int nextCheckPoint;

    public float normalSpeed;
    public float boostSpeed;

    public float backSpeed;
    private bool mayTurn;

    public float rotateSpeed;

    private Rigidbody _rb;


    void Start()
    {
        _rb = GetComponent<Rigidbody>();

    }
    void FixedUpdate()
    {
        VehicleMove();       
	}

    void VehicleMove()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        // Front Back
        _rb.velocity += y * transform.forward * normalSpeed * Time.deltaTime;

        // Turning
        if (y == 0)
        {
            mayTurn = false;
        }
        else
        {
            mayTurn = true;
            Vector3 a = transform.eulerAngles;

            float rotation = 0;
            if (x > 0)
            {
                rotation = a.y + rotateSpeed;
                transform.eulerAngles = new Vector3(a.x, rotation, a.z);
            }
            else if (x < 0)
            {
                rotation = a.y - rotateSpeed;
                transform.eulerAngles = new Vector3(a.x, rotation, a.z);
            }
        }       
    }

    void Boost()
    {
        normalSpeed = normalSpeed + boostSpeed;
    }

    void Slow()
    {
        _rb.drag = 1f;
    }

    void OnTriggerEnter(Collider col)
    {
        switch (col.tag)
        {
            case "Destructible":
                heldItem = (ItemType)Random.Range(1, 5);
                break;
            case "Boost":
                Boost();
                break;
            case "OffRoad":
                Slow();
                break;
        }
    }
    void OnTriggerExit(Collider col)
    {
        switch (col.tag)
        {
            case "Boost":
                FixedUpdate();
                break;
        }
    }
}


