using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_NonInt : MonoBehaviour
{
    [SerializeField] private SC_FPSController fpsController;
    [SerializeField] private Player_Interact playerInteract;
    [SerializeField] private GameObject containerGameObject;
    [SerializeField] private TMP_Text stateFalseText;
    [SerializeField] private TMP_Text stateTrueText;
    private bool pressedState;
    // Start is called before the first frame update
    void Start()
    {
        pressedState = false;
    }

    private void Update()
    {
        if (playerInteract.getNonInt() != null)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                if(pressedState == true)
                {
                    pressedState = false;
                } else
                {
                    pressedState = true;
                }
            }
            if (pressedState == true)
            {
                stateTrueText.SetText("Press X to Go Back");
                stateFalseText.SetText("");
                playerInteract.getNonInt().view();
                fpsController.freezeMovement();
            }
            else
            {
                stateFalseText.SetText("Press X to View");
                stateTrueText.SetText("");
                playerInteract.getNonInt().exitView();
                fpsController.bringMovement();
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
