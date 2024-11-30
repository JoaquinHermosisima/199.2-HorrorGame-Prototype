using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class TeaTable : MonoBehaviour
{
    [SerializeField] private Teacup[] teacups;
    [SerializeField] private Material defaultMatl;
    [SerializeField] private Material glow;
    public GameObject teapot;
    private bool allMatch;
    
    void Update()
    {
        CheckMaterials();
    }
    void CheckMaterials()
    {
        allMatch = true;
        foreach (Teacup cup in teacups)
        {
            if (cup.getServed() == false)
            {
                allMatch = false;
                break;
            }
        }

        if (allMatch)
        {
            teapot.GetComponent<Renderer>().material = glow;
        }
        else {
            teapot.GetComponent<Renderer>().material = defaultMatl;
        }
    }
}
