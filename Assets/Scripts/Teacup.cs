using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class Teacup : MonoBehaviour
{
    public GameObject teaLiquid;
    public Material matcha;
    public Material water;
    private Material currentLiquid;
    public bool served = false;
    [SerializeField] private Material assignedMaterial;
    // Start is called before the first frame update
    void Start()
    {
        teaLiquid.GetComponent<Renderer>().material = water;
        currentLiquid = water;
    }

    private void Update()
    {
        if(currentLiquid == assignedMaterial)
        {
            served = true;
        }
    }

    // Update is called once per frame
    public void pourTea()
    {
        if (currentLiquid == water)
        {
            teaLiquid.GetComponent<Renderer>().material = matcha;
            currentLiquid = matcha;
        }
        else
        {
            teaLiquid.GetComponent<Renderer>().material = water;
            currentLiquid = water;
        }
    }

    public bool getServed()
    {
        return served;
    }
}
