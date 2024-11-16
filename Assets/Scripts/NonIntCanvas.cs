using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NonIntCanvas : MonoBehaviour
{
    public GameObject canvas;
    // Start is called before the first frame update
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
