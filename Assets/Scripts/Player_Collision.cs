using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Collision : MonoBehaviour
{
    public Canvas canvas; // Assign the canvas in the Inspector
    public float detectionRange = 1.0f; // Adjust the detection range as needed

    private bool isCanvasActive = false;

    void Update()
    {
        // Check if the player is near a wall
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRange);
        foreach (var hitCollider in hitColliders)
        {
            // Check if the hit object is a wall
            if (hitCollider.CompareTag("Destructible"))
            {
                // Show the canvas when the player is near a wall
                if (!isCanvasActive)
                {
                    canvas.enabled = true;
                    isCanvasActive = true;
                }
            }
            else
            {
                // Hide the canvas when the player is not near a wall
                if (isCanvasActive)
                {
                    canvas.enabled = false;
                    isCanvasActive = false;
                }
            }
        }
        
        if (Input.GetKeyDown(KeyCode.E) && isCanvasActive)
        {
            canvas.enabled = true;
        }
    }
}
