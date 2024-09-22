using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Interact : MonoBehaviour
{   
    private bool toInteract = false;
    private bool screenActive = false;
    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && screenActive == false)
        {   
            float interactRange = 2f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray)
            {
                if(collider.TryGetComponent(out Char_Interactible charInteractible))
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
