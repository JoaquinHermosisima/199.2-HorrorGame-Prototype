using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    // Start is called before the first frame update
    public Block_Platform[] platforms;
    public GameObject canvas;
    private bool occupied;
    void Start()
    {
        canvas.SetActive(false);
    }

    void Update()
    {
        occupied = true;
        foreach (Block_Platform platform in platforms)
        {
            if (platform.getColliding() == false)
            {
                occupied = false;
                break;
            }
        }

        if (occupied)
        {
            canvas.SetActive(true);
        }
        else
        {
            canvas.SetActive(false);
        }

    }
}
