using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLight : MonoBehaviour
{
    [SerializeField] private Player_Interact playerInteract;
    public GameObject flashLight;
    public GameObject lantern;
    private bool obtained;
    private bool active;
    private int firstLight;
    private Coroutine flickerCoroutine; // To hold the flicker coroutine reference

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
        if (playerInteract.GetLantern() != null && Input.GetKeyDown(KeyCode.X))
        {
            if (obtained == false)
            {
                lantern.SetActive(false);
                obtained = true;
            }
        }

        if (obtained)
        {
            lightControl();
        }
    }

    void lightControl()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            active = !active; // Toggle the active state
            flashLight.SetActive(active);
            if (active)
            {
                if (firstLight == 0)
                {
                    firstLight = 1;
                }
                // Start the flickering coroutine after activating the light
                StartCoroutine(FlickerLight());
            }
            else
            {
                // Stop flickering when the light is turned off
                if (flickerCoroutine != null)
                {
                    StopCoroutine(flickerCoroutine);
                    flickerCoroutine = null; // Reset the coroutine reference
                }
                flashLight.GetComponent<Light>().enabled = true; // Ensure the light is on when deactivated
            }
        }
    }

    private IEnumerator FlickerLight()
    {
        // Wait for 30 seconds before starting to flicker
        yield return new WaitForSeconds(60f);

        Light lightComponent = flashLight.GetComponent<Light>();
        float interval = 0.5f; // Flicker interval
        float timer = 0f;

        while (active) // Continue flickering while the light is active
        {
            timer += Time.deltaTime;
            if (timer > interval)
            {
                lightComponent.enabled = !lightComponent.enabled; // Toggle light
                timer -= interval;
            }
            yield return null; // Wait for the next frame
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
/*using System.Collections;
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
}*/