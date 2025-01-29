using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_Appear : MonoBehaviour
{
    // This class makes the Block-Puzzle Cubes appear when the required
    // number of characters in the notebook has been set.
    // This code is placed on the Main floor of the Level
    public GameObject cube;
    [SerializeField] private int requiredChar;
    [SerializeField] private SC_FPSController fpsController;
    [SerializeField] private AudioSource doorOpenSound;
    private bool soundPlayed;
    void Start()
    {
        cube.SetActive(false);
        soundPlayed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(fpsController.getCharCount() >= requiredChar)
        {
            if (!soundPlayed) // Check if the sound hasn't been played
            {
                doorOpenSound.Play(); // Play the sound
                soundPlayed = true; // Set the flag to true to prevent replaying
            }
            cube.SetActive(true);
        }
    }
}
