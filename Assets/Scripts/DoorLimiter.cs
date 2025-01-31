using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoorLimiter : MonoBehaviour
{
    public SC_FPSController fpsController;
    public GameObject Door;
    public LevelDoorNonPUZ lev;
    void Start()
    { 
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fpsController.getCharCount() >= 16 && lev.getTeaServe() == true)
        {
            Door.SetActive(false);
        } else
        {
            Door.SetActive(true);
        }
    }
}
