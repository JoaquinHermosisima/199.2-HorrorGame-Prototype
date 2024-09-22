using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Timers;

public class Char_Interactible : MonoBehaviour
{
    public GameObject charCanvas;
    public TMP_InputField inputField;
    public TMP_Text textDisplay;
    public Button submitButton;
    public string input;
    public string correctChar;
    public string answer;
    private void Start()
    {
        charCanvas.SetActive(false);
    }
    public void Interact()
    {
        charCanvas.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        submitButton.onClick.AddListener(evalInput);
    }

    public void dontInteract()
    {
        charCanvas.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void getInput()
    {
        textDisplay.SetText(inputField.text);
    }

    public void evalInput()
    {
        answer = inputField.text;
        if (answer == correctChar)
        {
            textDisplay.SetText("Correct");
        }
        else
        {
            textDisplay.SetText("WRONG");
        }
        /*int count = 0;
        Timer timer = new Timer(5000);
        timer.Elapsed += (sender, e) =>
        {
            charCanvas.SetActive(false);
            count++;
        };
        answer = inputField.text;
        if(answer == correctChar)
        {
            textDisplay.SetText("Correct");
        } else
        {
            textDisplay.SetText("WRONG");
        }
        timer.Start();
        if (count > 0)
        {
            timer.Stop();
        }*/
    }

}
