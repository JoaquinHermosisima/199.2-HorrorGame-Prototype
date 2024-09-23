using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_INT : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.E) && popPanel.activeSelf)
        {
            popPanel.SetActive(false);
            charPanel.SetActive(true);
        }
    }
}
