using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCabPuzzle : MonoBehaviour
{
    [SerializeField] private BossCab_Lock[] locks;
    public GameObject character;
    private bool allMatch;
    void Start()
    {
        allMatch = false;
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

        if (allMatch)
        {
            character.SetActive(true);
        } else { 
            character.SetActive(false); 
        }
    }
}
