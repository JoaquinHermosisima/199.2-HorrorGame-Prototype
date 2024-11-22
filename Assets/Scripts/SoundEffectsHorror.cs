using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsHorror : MonoBehaviour
{

    public AudioClip backgroundMusic, notebookOpen, claimSound; // Assign the audio clip in the Inspector
    private AudioSource audioSource, gameSounds;

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
    public void NotebookOpen()
    {
        if (notebook.activeSelf == false) {
            gameSounds = gameObject.AddComponent<AudioSource>();
            gameSounds.clip = notebookOpen;
            gameSounds.Play();
        }
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
            NotebookOpen();
        }

        if(Input.GetKeyDown(KeyCode.X)) {
            ClaimSymbol();
        }
    }
}
