using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Char_Interactible : MonoBehaviour
{
    public GameObject charCanvas;
    public TMP_InputField inputField;
    public TMP_Text textDisplay;
    public Button submitButton;
    public Player_Movement player_movement;
    public string input;
    private void Start()
    {
        charCanvas.SetActive(false);
    } 
    public void Interact()
    {
        charCanvas.SetActive(true);
        player_movement.Hide_ShowMouseCursor();
        submitButton.onClick.AddListener(getInput);
    }

    public void dontInteract()
    {
        charCanvas.SetActive(false);
    }

    public void getInput()
    {
        textDisplay.SetText(inputField.text);
    }
}
