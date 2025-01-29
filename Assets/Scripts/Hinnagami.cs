using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hinnagami : MonoBehaviour
{
    public GameObject hint;
    public AudioSource hinaVoice;
    private bool hasPlayedAudio = false; // Track if audio has been played
    // Update is called once per frame

    public AudioSource getVoice()
    {
        return hinaVoice;
    }
    public GameObject getHint()
    {
        return hint;
    }

    public void hintOpen()
    {
        hint.SetActive(true);
    }

    public void hintClose()
    {
        hint.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasPlayedAudio) // Check if the player enters the trigger
        {
            hinaVoice.Play(); // Play the audio
            hasPlayedAudio = true; // Set the flag to true to prevent replaying
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the player exits the trigger
        {
            hasPlayedAudio = false; // Reset the flag to allow audio to play again next time
        }
    }

}
