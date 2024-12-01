using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDoorNonPUZ : MonoBehaviour
{
    public GameObject Door;
    [SerializeField] private TeaTable[] tables;
    private bool allMatch;
    // Start is called before the first frame update
    void Start()
    {
        allMatch = false;
    }

    // Update is called once per frame
    void Update()
    {
        checkTables();
    }

    void checkTables()
    {
        allMatch = true;
        foreach (TeaTable table in tables)
        {
            if (table.getMatch() == false)
            {
                allMatch = false;
                break;
            }
        }
        
        if (allMatch)
        {
            Door.SetActive(false);
        }
    }
}
