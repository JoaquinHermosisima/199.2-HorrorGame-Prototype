using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class KatanaPuzzle : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject roChar;
    [SerializeField] private Katana[] KatanaTables;
    private bool allMatch;
    void Start()
    {
        roChar.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CheckTables();
    }

    void CheckTables()
    {
        allMatch = true;
        foreach (Katana table in KatanaTables)
        {
            print(table.name + " " + table.getIsCorrect());
            if (table.getIsCorrect() == false)
            {
                allMatch = false;
                break;
            }
        }

        if (allMatch)
        {
            roChar.SetActive(true);
        }
    }
}
