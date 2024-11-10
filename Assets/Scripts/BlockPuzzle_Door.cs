using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPuzzle_Door : MonoBehaviour
{
    // Start is called before the first frame update
    //public Material glow;
    public Platform_Color platform1;
    public Platform_Color platform2;
    public GameObject door;
    void Start()
    {
        door.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (platform1.getColliding() == true && platform2.getColliding() == true) { 
            door.SetActive(false);
        } else
        {
            door.SetActive(true);
        }
    }
}
