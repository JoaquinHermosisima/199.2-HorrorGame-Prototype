using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Interact : MonoBehaviour
{   
    //This Class Opens the Char_Interactible Canvases
    private bool toInteract = false;
    private bool screenActive = false;
    [SerializeField] private SC_FPSController fpsController;
    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {   
            float interactRange = 2f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray)
            {
                
                if(collider.TryGetComponent(out Char_Interactible charInteractible))
                {
                    if(fpsController.getCharCount() >= charInteractible.getRequiredChar())
                    {
                        toInteract = !toInteract;

                        if (toInteract == true)
                        {
                            charInteractible.Interact();
                            screenActive = true;
                        }
                        if (toInteract == false)
                        {
                            charInteractible.dontInteract();
                            screenActive = false;
                        }
                    }
                    
                }

            }
        }

    }

    public Char_Interactible getChar_Interactible()
    {
        float interactRange = 2f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent(out Char_Interactible charInteractible))
            {
                return charInteractible;
            }

        }
        return null;
    }
}
