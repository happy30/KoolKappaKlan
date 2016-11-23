﻿//Made by Sascha Greve

using UnityEngine;
using System.Collections;

public class DestructibleScript : MonoBehaviour
{
    public GameObject particleObject;
    GameObject spawnedParticleObject;
    GameObject self;

    void Start()
    {
        self = gameObject;
    }

    public void DestroyObject ()
    {
        Destroy(spawnedParticleObject = (GameObject)Instantiate(particleObject, transform.position, Quaternion.identity), 3);
        Destroy(gameObject);
    }
}
