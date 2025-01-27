using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossVertiLock : MonoBehaviour
{
    [SerializeField] private Material[] materials;
    private int currentMaterialIndex;
    public int vertiLockOrder;
    [SerializeField] private int correctIndex;
    public bool isCorrect;
    [SerializeField] private BossKatana katBlock;
    [SerializeField] private BossKatana katMatl;

    void Start()
    {
        currentMaterialIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentMaterialIndex == correctIndex)
        {
            isCorrect = true;
        }
        else
        {
            isCorrect = false;
        }
        if (katBlock.getCurrentAngle() == vertiLockOrder)
        {
            switch (katMatl.getCurrentAngle())
            {
                case 0:
                    currentMaterialIndex = 0;
                    break;
                case 1:
                    currentMaterialIndex = 1;
                    break;
                case 2:
                    currentMaterialIndex = 2;
                    break;
                case 3:
                    currentMaterialIndex = 3;
                    break;
                case 4:
                    currentMaterialIndex = 4;
                    break;
            }
            GetComponent<Renderer>().material = materials[currentMaterialIndex];
        }

    }
    public bool GetIsCorrect()
    {
        return isCorrect;
    }
}
