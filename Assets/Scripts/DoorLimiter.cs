using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoorLimiter : MonoBehaviour
{
    public SC_FPSController fpsController;
    [SerializeField] private TMP_Text textDisplay;
    public GameObject Door;
    public int charNeeded;
    void Start()
    { 
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fpsController.getCharCount() >= charNeeded)
        {
            Door.SetActive(true);
            textDisplay.SetText(" ");
        } else
        {
            Door.SetActive(false);
            textDisplay.SetText("You are lacking characters");
        }
    }
}
