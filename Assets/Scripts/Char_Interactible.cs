using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Timers;
using UnityEditor.Animations;

public class Char_Interactible : MonoBehaviour
{
    public GameObject charCanvas;
    public GameObject charBlock;
    public TMP_InputField inputField;
    public TMP_Text textDisplay;
    public Button submitButton;
    //public string input;
    public string correctChar;
    public string answer;
    public bool isAnswered;
    public bool triggered;
    private void Start()
    {
        charCanvas.SetActive(false);
        isAnswered = false;
        triggered = false;
    }

    private void Update()
    {
        if (isAnswered)
        {
            charBlock.SetActive(false);
        }
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

    public void evalInput()
    {
        answer = inputField.text;
        answer = answer.ToUpper();
        if (answer == correctChar)
        {
            textDisplay.SetText("Correct");
        }
        else
        {
            textDisplay.SetText("WRONG");
        }
        StartCoroutine(DestroyCanvas());

    }

    IEnumerator DestroyCanvas()
    {
        yield return new WaitForSeconds(1);
        charCanvas.SetActive(false);
        textDisplay.SetText("what character is this");
        inputField.text = "";
        if(answer == correctChar)
        {
            isAnswered = true;
        }
    }

    IEnumerator RespawnBlock()
    {
        yield return new WaitForSeconds(1);
    }

    /*public bool getStatus()
    {
        return isAnswered;
    }*/

}
