using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Platform : MonoBehaviour
{
    /* This class is in charge of managing the glow of the platform
        for block_based levels
     */

    public GameObject platform;
    public Material wood;
    public Material green_glow;
    public bool isColliding;
    [SerializeField] private string cube;
    void Start()
    {
        platform.GetComponent<Renderer>().material = wood;
        isColliding = false;
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == cube)
        {
            platform.GetComponent<Renderer>().material = green_glow;
            isColliding = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == cube)
        {
            platform.GetComponent<Renderer>().material = wood;
            isColliding = false;
        }
    }

    public bool getColliding()
    {
        return isColliding;
    }
}
