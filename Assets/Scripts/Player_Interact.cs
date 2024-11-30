using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Player_Interact : MonoBehaviour
{   
    //This Class allows Player to interact with various objects
    private bool toInteract = false;
    private bool screenActive = false;
    [SerializeField] private SC_FPSController fpsController;
    [SerializeField] private LayerMask pickableLayer;
    [SerializeField] private LayerMask nonIntLayer;
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
                            fpsController.freezeMovement();
                        }
                        if (toInteract == false)
                        {
                            charInteractible.dontInteract();
                            screenActive = false;
                            fpsController.bringMovement();
                        }
                    }
                }
                if (collider.TryGetComponent(out KatanaTable table))
                {
                    table.rotateKatana();
                }
            }

            float teaRange = 1.0f;
            Collider[] teaColliderArray = Physics.OverlapSphere(transform.position, teaRange);
            foreach (Collider collider in teaColliderArray)
            {
                if (collider.TryGetComponent(out Teacup teacup))
                {
                    teacup.pourTea();
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
    public NonIntCanvas getNonInt()
    {
        float interactRange = 2f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent(out NonIntCanvas nonInt))
            {
                return nonInt;
            }

        }
        return null;
    }

    public Teacup getTeacup()
    {
        float interactRange = 2f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent(out Teacup teacup))
            {
                return teacup;
            }

        }
        return null;
    }

    public GameObject getPickableObject()
    {
        float interactRange = 2f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray)
        {
            // Check if the collider's GameObject is in the pickable layer
            if (IsInLayerMask(collider.gameObject, pickableLayer))
            {
                return collider.gameObject; // Return the GameObject if it's pickable
            }
        }
        return null; // Return null if no pickable objects are found
    }
    public GameObject GetLantern()
    {
        float interactRange = 2f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray)
        {
            // Check if the collider's GameObject has the specified tag
            if (collider.CompareTag("Flashlight"))
            {
                return collider.gameObject;
            }
        }
        return null; // Return null if no objects with the specified tag are found
    }

    private bool IsInLayerMask(GameObject obj, LayerMask layerMask)
    {
        return (layerMask & (1 << obj.layer)) != 0;
    }
}
