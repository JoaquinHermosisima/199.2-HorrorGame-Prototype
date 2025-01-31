using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDoorNonPUZ : MonoBehaviour
{
    public GameObject Door;
    [SerializeField] private TeaTable[] tables;
    private bool allMatch;
    private bool doorOpened;
    private bool soundPlayed;
    [SerializeField] private AudioSource doorOpenSound;
    // Start is called before the first frame update
    void Start()
    {
        allMatch = false;
        doorOpened = false; // Initialize the doorOpened flag to false
        soundPlayed = false; // Initialize the soundPlayed flag to false
    }

    // Update is called once per frame
    void Update()
    {
        checkTables();
        if (allMatch && !doorOpened) // Check if all platforms are occupied and door hasn't been opened
        {
            doorOpened = true; // Set the flag to true to prevent reopening
            if (!soundPlayed) // Check if the sound hasn't been played
            {
                doorOpenSound.Play(); // Play the door opening sound
                soundPlayed = true; // Set the flag to true to prevent replaying
            }
        }
        else if (!allMatch && doorOpened) // Check if not all platforms are occupied and door is opened
        {
            doorOpened = false; // Reset the flag to allow reopening when conditions are met again
            soundPlayed = false; // Reset the soundPlayed flag to allow sound to play again when door opens
        }
    }

    void checkTables()
    {
        allMatch = true;
        foreach (TeaTable table in tables)
        {
            if (table.getMatch() == false)
            {
                allMatch = false;
                break;
            }
        }
        
        if (allMatch)
        {
            Door.SetActive(false);
        }
    }
}
