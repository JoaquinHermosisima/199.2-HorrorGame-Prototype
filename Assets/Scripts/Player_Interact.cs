using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Interact : MonoBehaviour
{
    public GameObject charBlock;
    public GameObject charPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            charPanel.SetActive(!charPanel.activeSelf);
            
            /*float interactRange = 2f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray)
            {
                if(collider.TryGetComponent(out Char_Interactible charInteractible))
                {
                    charInteractible.Interact();
                }
            }*/
        }
        
    }
}
