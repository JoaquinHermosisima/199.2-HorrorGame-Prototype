using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class KatanaPuzzle : MonoBehaviour
{
    [SerializeField] private Katana[] katanas;
    [SerializeField] private GameObject roChar;
    private bool allMatch;
    // Start is called before the first frame update
    void Start()
    {
        roChar.SetActive(true);
        allMatch = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        allMatch = true;
        foreach (Katana katana in katanas)
        {
            if (katana.GetIsCorrect() == false)
            {
                allMatch = false;
                break;
            }
        }

        if (allMatch)
        {
            roChar.SetActive(false);
        }
    }
}
