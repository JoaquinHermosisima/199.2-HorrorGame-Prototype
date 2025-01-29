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
    [SerializeField] private AudioSource doorOpenSound;
    private bool occupied;
    private bool doorOpened;
    private bool soundPlayed;

    void Start()
    {
        door.SetActive(true);
        doorOpened = false; // Initialize the doorOpened flag to false
        soundPlayed = false; // Initialize the soundPlayed flag to false
    }

    void Update()
    {
        occupied = true;
        foreach (Block_Platform platform in platforms)
        {
            if (!platform.getColliding())
            {
                occupied = false;
                break;
            }
        }

        if (occupied && !doorOpened) // Check if all platforms are occupied and door hasn't been opened
        {
            openDoor();
            doorOpened = true; // Set the flag to true to prevent reopening
            if (!soundPlayed) // Check if the sound hasn't been played
            {
                doorOpenSound.Play(); // Play the door opening sound
                soundPlayed = true; // Set the flag to true to prevent replaying
            }
        }
        else if (!occupied && doorOpened) // Check if not all platforms are occupied and door is opened
        {
            closeDoor();
            doorOpened = false; // Reset the flag to allow reopening when conditions are met again
            soundPlayed = false; // Reset the soundPlayed flag to allow sound to play again when door opens
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
/*using System;
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
}*/