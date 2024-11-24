using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerLight : MonoBehaviour
{
    [SerializeField] private Player_Interact playerInteract;
    public GameObject flashLight;
    public GameObject lantern;
    private bool obtained;
    private bool active;
    private int firstLight;

    void Start()
    {
        flashLight.SetActive(false);
        active = false;
        obtained = false;
        firstLight = 0;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (playerInteract.GetLantern() != null && Input.GetKeyDown(KeyCode.X)) { 
            if(obtained == false)
            {
                lantern.SetActive(false);
                obtained = true;
            }
        }
        
        if (obtained) {
            lightControl();
        }
        
    }

    void lightControl()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (active == false)
            {
                active = true;
            }
            else
            {
                active = false;
            }
            flashLight.SetActive(active);
            if (firstLight == 0) {
                firstLight = 1;
            }
        }
    }

    public bool getObtained()
    {
        return obtained;
    }

    public int getFirstLight()
    {
        return firstLight;
    }
}