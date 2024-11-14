using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Door : MonoBehaviour
{
    // This class is in charge of opening doors in Block-Based Levels
    public Block_Platform platform;
    public GameObject door;
    void Start()
    {
        door.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (platform.getColliding() == true)
        {
            door.SetActive(false);
        }
        else
        {
            door.SetActive(true);
        }
    }
}