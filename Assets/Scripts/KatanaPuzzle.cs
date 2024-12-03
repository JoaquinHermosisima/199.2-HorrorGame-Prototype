using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatanaPuzzle : MonoBehaviour
{
    public GameObject RoChar;
    public GameObject TeaPuzzle;
    [SerializeField] private Katana[] katanas;
    private bool allMatch;
    // Start is called before the first frame update
    void Start()
    {
        allMatch = false;
        RoChar.SetActive(false);
        TeaPuzzle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        checkTables();
    }

    void checkTables()
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
            RoChar.SetActive(true);
            TeaPuzzle.SetActive(true);
        }
    }
}
