using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{

    // claimSound
    public AudioClip notebookOpen; // Assign the audio clip in the Inspector
    private AudioSource audioSource, gameSounds;

    public AudioSource walkingSound, lanternStart;
    bool lanternEnable = false;

    [SerializeField] GameObject notebook;

    void Start()
    {
    }

    // Update is called once per frame
    public void NotebookSounds()
    {
        gameSounds = gameObject.AddComponent<AudioSource>();
        gameSounds.volume = 0.01f;
        gameSounds.clip = notebookOpen;
        gameSounds.Play();
        
    }

    //public void ClaimSymbol() 
    //{
    //    gameSounds = gameObject.AddComponent<AudioSource>();
    //    gameSounds.clip = claimSound;
    //    gameSounds.Play();
    //}


    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Q)) {
            NotebookSounds();
        }

        //if(Input.GetKeyDown(KeyCode.X)) {
        //    ClaimSymbol();
        //}

        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) {
            walkingSound.enabled = true;
        } else {
            walkingSound.enabled = false;
        }

        if(Input.GetKey(KeyCode.F) && (lanternEnable == false)) {
            lanternEnable = true;
            lanternStart.enabled = true;
        } else if (Input.GetKey(KeyCode.F) && lanternEnable) {
            lanternEnable = false;
            lanternStart.enabled = false;
        }
    }
}
