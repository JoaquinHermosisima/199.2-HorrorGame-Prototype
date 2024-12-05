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
    [SerializeField] private TMP_Text stateTrueText;
    private bool pressedState;
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
                stateTrueText.SetText(playerInteract.GetHinnagami().getHint());
                stateFalseText.SetText("");
            }
            else
            {
                playerInteract.GetHinnagami().getVoice().Play();
                stateFalseText.SetText("Press X to View");
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