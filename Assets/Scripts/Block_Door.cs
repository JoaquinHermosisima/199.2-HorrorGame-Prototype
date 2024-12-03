using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Door : MonoBehaviour
{
    // This class is in charge of opening doors in Block-Based Levels
    // Place this on the floor of the door level
    public Block_Platform[] platforms;
    public GameObject door;
    private bool occupied;
    void Start()
    {
        door.SetActive(true);
    }

    void Update()
    {
        occupied = true;
        foreach (Block_Platform platform in platforms)
        {
            if (platform.getColliding() == false)
            {
                occupied = false;
                break;
            }
        }

        if (occupied)
        { 
            openDoor();
        } else
        {
            closeDoor();
        }

    }
    private void openDoor()
    {
        door.SetActive(false);
    }

    private void closeDoor()
    {
        door.SetActive(true);
    }
}