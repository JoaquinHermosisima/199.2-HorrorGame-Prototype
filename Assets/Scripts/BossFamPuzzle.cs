using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFamPuzzle : MonoBehaviour
{
    [SerializeField] private BossVertiLock[] locks;
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
        foreach (BossVertiLock bosslock in locks)
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
            soundPlayed = true;
        }
        else
        {
            character.SetActive(false);
        }
    }
}
