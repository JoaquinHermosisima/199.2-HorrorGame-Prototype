using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Cube : MonoBehaviour
{
    [SerializeField] private Player_Interact playerInteract;
    [SerializeField] private GameObject containerGameObject;
    [SerializeField] private TMP_Text stateFalseText;
    [SerializeField] private TMP_Text stateTrueText;
    [SerializeField] private PickUpObject pickUpObject;

    private void Update()
    {
        if (playerInteract.getPickableObject() != null)
        {
            if (pickUpObject.getPickedUpState() == true)
            {
                stateTrueText.SetText("Press X to Drop");
                stateFalseText.SetText("");
            }
            else
            {
                stateFalseText.SetText("Press X to Pick Up");
                stateTrueText.SetText("");
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
