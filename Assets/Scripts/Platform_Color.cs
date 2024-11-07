using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Platform_Color : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject platform;
    public Material red_glow;
    public Material green_glow;
    [SerializeField] private string cube;
    void Start()
    {
        platform.GetComponent<Renderer>().material = red_glow;
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision )
    {
        if(collision.gameObject.tag == cube)
        {
            platform.GetComponent<Renderer>().material = green_glow;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == cube)
        {
            platform.GetComponent<Renderer>().material = red_glow;
        }
    }
}
