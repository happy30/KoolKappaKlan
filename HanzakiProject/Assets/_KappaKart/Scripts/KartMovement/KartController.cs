//Made by Faf
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartController : MonoBehaviour
{
    public enum ItemType { None, Hook, Shuriken, Katana, Box, Bomb, SecondNone }
    public ItemType heldItem;

    public bool raceStarted;
    public int nextCheckPoint;
    public int playerPos;
    public GameObject otherPlayer;

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

    void Update()
    {
        if(otherPlayer.GetComponent<KartController>().nextCheckPoint < nextCheckPoint)
        {

        }
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

    void OnTriggerEnter(Collider col)
    {
        switch (col.tag)
        {
            case "ItemBox":
                if (heldItem == ItemType.None)
                {
                    if (playerPos < 2) // if Number 1
                    {
                        heldItem = (ItemType)Random.Range(1, 5);
                    }
                    else //  if Number 2
                    {
                        heldItem = (ItemType)Random.Range(2, 6);
                    }

                }            
                break;
            case "Boost":
                normalSpeed = normalSpeed + boostSpeed;
                break;
            case "OffRoad":
                _rb.drag = 1f;
                break;
        }
    }
    void OnTriggerExit(Collider col)
    {
        switch (col.tag)
        {
            case "ItemBox":
                GetItem();
                break;
            case "Boost":
                normalSpeed = normalSpeed - boostSpeed;
                break;
            case "OffRoad":
                _rb.drag = 0f;
                break;
        }
    }

    void GotHit()
    {

    }

    void GetItem()
    {

    }

    void UseItem()
    {

    }


}


