using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public GameObject flashlight;
    public bool obtained;
    // Start is called before the first frame update
    void Start()
    {
        obtained = false;
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            obtained = true;
            flashlight.SetActive(false);
        }
    }

    public bool isObtained()
    {
        return obtained;
    }
}
