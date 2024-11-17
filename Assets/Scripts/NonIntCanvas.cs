using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NonIntCanvas : MonoBehaviour
{
    //This Class is for objects that you can view to zoom
    public GameObject canvas;
    void Start()
    {
        canvas.SetActive(false);
    }


    public void view()
    {
        canvas.SetActive(true);
    }

    public void exitView()
    {
        canvas.SetActive(false);
    }
}
