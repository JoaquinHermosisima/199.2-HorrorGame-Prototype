using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Hinnagami : MonoBehaviour
{
    [SerializeField] private SC_FPSController fpsController;
    [SerializeField] private Player_Interact playerInteract;
    [SerializeField] private GameObject containerGameObject;
    [SerializeField] private TMP_Text stateFalseText;
    private bool pressedState;
    //private bool hasPlayedAudio = false; // Track if audio has been played
    // Start is called before the first frame update
    void Start()
    {
        pressedState = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInteract.GetHinnagami() != null)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                if (pressedState == true)
                {
                    pressedState = false;
                    
                }
                else
                {
                    pressedState = true;
                }
            }
            if (pressedState == true)
            {
                playerInteract.GetHinnagami().hintOpen();
                playerInteract.GetHinnagami().getVoice().Play();
                fpsController.freezeMovement();
                stateFalseText.SetText("");
            }
            else
            {
                playerInteract.GetHinnagami().hintClose();
                fpsController.bringMovement();
                stateFalseText.SetText("Press X");
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