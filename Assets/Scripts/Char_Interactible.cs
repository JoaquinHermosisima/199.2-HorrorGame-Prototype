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
    // This class contains the code for the Flashcard Canvas
    public SC_FPSController fpsController;
    public GameObject charCanvas_1;
    public GameObject charCanvas_2;
    public GameObject door;
    public TMP_InputField inputField_1;
    public TMP_InputField inputField_2;
    public TMP_Text textDisplay_1;
    public TMP_Text textDisplay_2;
    public string correctChar_1;
    public string correctChar_2;
    public string answer_1;
    public string answer_2;
    public bool isAnswered;
    public int requiredChar;

    private void Start()
    {
        charCanvas_1.SetActive(false);
        charCanvas_2.SetActive(false);
        isAnswered = false;
    }

    private void Update()
    {
        if (isAnswered)
        {
            door.SetActive(false);
        }

        // Check for Enter key press to submit the input
        if (charCanvas_1.activeSelf && Input.GetKeyDown(KeyCode.Return))
        {
            evalInput0();
        }
        else if (charCanvas_2.activeSelf && Input.GetKeyDown(KeyCode.Return))
        {
            evalInput1();
        }
    }

    public void Interact()
    {
        System.Random rnd = new System.Random();
        int num = rnd.Next(0, 2);
        if (num == 0)
        {
            charCanvas_1.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            inputField_1.Select();
        }
        else if (num == 1)
        {
            charCanvas_2.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            inputField_2.Select();
        }
    }

    public void dontInteract()
    {
        charCanvas_1.SetActive(false);
        charCanvas_2.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void evalInput0()
    {
        answer_1 = inputField_1.text.ToUpper();
        if (answer_1 == correctChar_1)
        {
            textDisplay_1.SetText("Correct");
        }
        else
        {
            textDisplay_1.SetText("WRONG");
        }
        StartCoroutine(DestroyCanvas0());
    }

    public void evalInput1()
    {
        answer_2 = inputField_2.text.ToUpper();
        if (answer_2 == correctChar_2)
        {
            textDisplay_2.SetText("Correct");
        }
        else
        {
            textDisplay_2.SetText("WRONG");
        }
        StartCoroutine(DestroyCanvas1());
    }

    public int getRequiredChar()
    {
        return requiredChar;
    }

    IEnumerator DestroyCanvas0()
    {
        yield return new WaitForSeconds(1);
        fpsController.bringMovement();
        charCanvas_1.SetActive(false);
        textDisplay_1.SetText("What character is this?");
        inputField_1.text = "";
        if (answer_1 == correctChar_1)
        {
            isAnswered = true;
        }
    }

    IEnumerator DestroyCanvas1()
    {
        yield return new WaitForSeconds(1);
        fpsController.bringMovement();
        charCanvas_2.SetActive(false);
        textDisplay_2.SetText("What character is this?");
        inputField_2.text = "";
        if (answer_2 == correctChar_2)
        {
            isAnswered = true;
        }
    }

    IEnumerator RespawnBlock()
    {
        yield return new WaitForSeconds(1);
    }
}