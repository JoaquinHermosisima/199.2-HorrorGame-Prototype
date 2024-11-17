using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_Appear : MonoBehaviour
{
    // This class makes the Cube appear when the required
    // number of characters in the notebook has been set.
    // This code is placed on the Main floor of the Level
    public GameObject cube;
    [SerializeField] private int requiredChar;
    [SerializeField] private SC_FPSController fpsController;
    void Start()
    {
        cube.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(fpsController.getCharCount() >= requiredChar)
        {
            cube.SetActive(true);
        }
    }
}
