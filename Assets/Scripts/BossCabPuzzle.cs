using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BossCabPuzzle : MonoBehaviour
{
    [SerializeField] private BossCab_Lock[] locks;
    public GameObject character;
    private bool allMatch;
    [SerializeField] private AudioSource blockSound;
    private bool soundPlayed;
    void Start()
    {
        allMatch = false;
        soundPlayed = false;
        character.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        allMatch = true;
        foreach (BossCab_Lock bosslock in locks)
        {
            if (bosslock.GetIsCorrect() == false)
            {
                allMatch = false;
                break;
            }
        }

        if (allMatch && !soundPlayed)
        {
            character.SetActive(true);
            blockSound.Play();
            soundPlayed = true; // Set the flag to true to prevent replaying

        } else { 
            character.SetActive(false); 
        }

    }
}
