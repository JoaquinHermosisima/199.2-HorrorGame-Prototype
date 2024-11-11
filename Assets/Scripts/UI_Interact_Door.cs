using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteractUI : MonoBehaviour
{
    //This Class is for the PressX UI of the Door
    [SerializeField] private GameObject containerGameObject;
    [SerializeField] private Player_Interact playerInteract;
    [SerializeField] private SC_FPSController fpsController;
    [SerializeField] private TMP_Text textDisplay;

    private void Update()
    {
        if (playerInteract.getChar_Interactible() != null) {
            if (fpsController.getCharCount() < 5) {
                textDisplay.SetText("You need to Collect all characters in the room");
            } else
            {
                textDisplay.SetText("Press X");
            }
            Show();
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
