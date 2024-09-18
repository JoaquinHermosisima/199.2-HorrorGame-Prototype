using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_Block : MonoBehaviour, I_Interactible
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt  => _prompt;
    public bool Interact(Interactor interactor) 
    {
        Debug.Log("Opening Block");
        return true;
    }
}