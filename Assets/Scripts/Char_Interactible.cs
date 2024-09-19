using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Char_Interactible : MonoBehaviour
{
    public GameObject popPanel;
    public GameObject charPanel;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player_Object"))
        {
            popPanel.SetActive(true);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && popPanel.activeSelf) {
            popPanel.SetActive(false);
            charPanel.SetActive(true);
        }
    }
}
