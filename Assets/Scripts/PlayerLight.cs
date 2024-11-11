using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLight : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject spotLight;
    public GameObject flashlight;
    public bool obtained;
    private bool active;
    // Start is called before the first frame update
    void Start()
    {
        spotLight.SetActive(false);
        active = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Flashlight")
        {
            obtained = true;
            flashlight.SetActive(false);
        }
    }
    
    // Update is called once per frame
    void Update()
    {

        if (obtained == true)
        {
            if (Input.GetKeyDown(KeyCode.F) && spotLight.activeSelf)
        {
            spotLight.SetActive(false);
            //active = false;
            }
            else if (Input.GetKeyDown(KeyCode.F))
            {
                spotLight.SetActive(true);
                //active = true;
            }
        }
    }
}
