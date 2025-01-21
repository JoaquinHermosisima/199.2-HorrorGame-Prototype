using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCab_Lock : MonoBehaviour
{
    [SerializeField] private Material[] materials;
    private int currentMaterialIndex;
    [SerializeField] private int correctIndex;
    public bool isCorrect;

    void Start()
    {
        currentMaterialIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentMaterialIndex == correctIndex)
        {
            isCorrect = true;
        } else
        {
            isCorrect = false;
        }
    }

    public void rotate()
    {
        currentMaterialIndex = (currentMaterialIndex + 1) % materials.Length;
        GetComponent<Renderer>().material = materials[currentMaterialIndex];
    }

    public bool GetIsCorrect()
    {
        return isCorrect;
    }
}
