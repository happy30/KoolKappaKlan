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
   // public GameObject otherPlayer;

    public float normalSpeed;
    public float boostSpeed;

    public float backSpeed;
    private bool mayTurn;

    public float rotateSpeed;
    public float restoreRotationSpeed;

    public float hoverHeight;
    public float hoverForce;
    public float hoverDamp;

    private Rigidbody _rb;


    void Start()
    {
        _rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
    }
    void FixedUpdate()
    {
        VehicleMove();

        
        RaycastHit hit;
        if (!Physics.Raycast(transform.position, -transform.up, out hit, 1.5f))
        {
            print("IN AIIR");
            transform.eulerAngles = new Vector3(
                Mathf.LerpAngle(transform.eulerAngles.x, 0, restoreRotationSpeed * Time.deltaTime),
                transform.eulerAngles.y,
                0);
        }
        else
        {
            transform.eulerAngles = new Vector3(
             Mathf.LerpAngle(transform.eulerAngles.x, 0, restoreRotationSpeed * 0.2f * Time.deltaTime),
             transform.eulerAngles.y,
             0);
        }
            Ray downRay = new Ray(transform.position, -Vector3.up);
            if (Physics.Raycast(downRay, out hit))
            {
                float hoverError = hoverHeight - hit.distance;
                if (hoverError > 0)
                {
                    float upwardSpeed = _rb.velocity.y;
                    float lift = hoverError * hoverForce - upwardSpeed * hoverDamp;
                    _rb.AddForce(lift * Vector3.up);
                }
            }
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

    void CheckFloor()
    {

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

    void GetItem()
    {

    }

}




