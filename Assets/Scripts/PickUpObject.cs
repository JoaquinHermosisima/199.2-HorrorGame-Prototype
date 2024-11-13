using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class PickUpObject : MonoBehaviour
{
    //This Class is in charge of the Player picking up the Blocks
    private GameObject heldObject;
    public float radius = 2f;
    public float distance = 2f;
    public float height = 1f;
    public bool pickedUp = false;

    private void Update()
    {
        var t = transform;
        var pressed = Input.GetKeyDown(KeyCode.X);
        if (heldObject)
        {
            var rigidBody = heldObject.GetComponent<Rigidbody>();
            var moveTo = t.position + distance * t.forward + height * t.up;
            var difference = moveTo - heldObject.transform.position;
            rigidBody.AddForce(difference * 500);
            heldObject.transform.rotation = t.rotation;
            if (pressed)
            {
                pickedUp = false;
                rigidBody.drag = 1f;
                rigidBody.useGravity = true;
                rigidBody.constraints = RigidbodyConstraints.None;
                heldObject = null;
            }
        }
        else
        {
            if (pressed)
            {
                // Define a layer mask for the "Pickupable" layer
                int layerMask = LayerMask.GetMask("Pickable"); // Adjust the layer name as needed

                // Perform the sphere cast
                var hits = Physics.SphereCastAll(t.position + t.forward, radius, t.forward, radius, layerMask);

                // Check if any hits were found
                if (hits.Length > 0)
                {
                    var hitObject = hits[0].transform.gameObject; // Get the first hit object
                    heldObject = hitObject;

                    var rigidBody = heldObject.GetComponent<Rigidbody>();
                    rigidBody.constraints = RigidbodyConstraints.FreezeRotation;
                    rigidBody.drag = 25f;
                    rigidBody.useGravity = false;
                    pickedUp = true;
                }
            }
        }
    }

    public bool getPickedUpState()
    {
        return pickedUp;
    }
}
