using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsHorror : MonoBehaviour
{

    public AudioClip backgroundMusic, notebookOpen, claimSound, walk, fire; // Assign the audio clip in the Inspector
    private AudioSource audioSource, gameSounds;

    public AudioSource walkingSound, lanternSound;
    bool lanternEnable = false;

    [SerializeField] GameObject notebook;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = backgroundMusic;
        audioSource.volume = 0.2f;
        audioSource.loop = true;
        //audioSource.playOnAwake = false; // Disable Play On Awake if you want to control it
        audioSource.Play(); // Start playing music
    }

    // Update is called once per frame
    public void NotebookSounds()
    {
        gameSounds = gameObject.AddComponent<AudioSource>();
        gameSounds.clip = notebookOpen;
        gameSounds.Play();
        
    }

    public void ClaimSymbol() 
    {
        gameSounds = gameObject.AddComponent<AudioSource>();
        gameSounds.clip = claimSound;
        gameSounds.Play();
    }


    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Q)) {
            NotebookSounds();
        }

        if(Input.GetKeyDown(KeyCode.X)) {
            ClaimSymbol();
        }

        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) {
            walkingSound.enabled = true;
        } else {
            walkingSound.enabled = false;
        }

        if(Input.GetKey(KeyCode.F) && (lanternEnable == false)) {
            lanternEnable = true;
            lanternSound.enabled = true;
        } else if (Input.GetKey(KeyCode.F) && lanternEnable) {
            lanternEnable = false;
            lanternSound.enabled = false;
        }
    }
}
