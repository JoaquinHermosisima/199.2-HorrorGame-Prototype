using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Lvl4Door : MonoBehaviour
{
    [SerializeField] private Player_Interact playerInteract;
    [SerializeField] private SC_FPSController fpsController;
    [SerializeField] private GameObject containerGameObject;
    void Start()
    {

    }

    void Update()
    {
        if (playerInteract.GetLVL4Door() != null)
        {
            if (fpsController.getCharCount() < 16)
            {
                Show();
            }
        }
        else
        {
            Hide();
        }

    }

    private void Show()
    {
        containerGameObject.SetActive(true);
    }

    private void Hide()
    {
        containerGameObject.SetActive(false);
    }
}
