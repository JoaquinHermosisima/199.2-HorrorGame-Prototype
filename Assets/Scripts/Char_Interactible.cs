using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Char_Interactible : MonoBehaviour
{
    public GameObject charCanvas;

    private void Start()
    {
        charCanvas.SetActive(false);
    }
    public void Interact()
    {
        charCanvas.SetActive(true);
    }

    public void dontInteract()
    {
        charCanvas.SetActive(false);
    }
}
