/*
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
            // Check for the X key press to toggle the pressed state
            if (Input.GetKeyDown(KeyCode.X))
            {
                pressedState = !pressedState; // Toggle pressedState
            }

            // If the pressedState is true, show the hint
            if (pressedState)
            {
                playerInteract.GetHinnagami().hintOpen();
                fpsController.freezeMovement();
                stateFalseText.SetText("");
            }
            else
            {
                // Play the voice only when the state is pressed to false
                if (!playerInteract.GetHinnagami().getVoice().isPlaying) // Check if the voice is already playing
                {
                    playerInteract.GetHinnagami().getVoice().Play();
                }
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
}*/
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
    private bool canPlayVoice = true; // Track if the voice can be played

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
            // Check for the X key press to toggle the pressed state
            if (Input.GetKeyDown(KeyCode.X))
            {
                pressedState = !pressedState; // Toggle pressedState
            }

            // If the pressedState is true, show the hint
            if (pressedState)
            {
                playerInteract.GetHinnagami().hintOpen();
                fpsController.freezeMovement();
                stateFalseText.SetText("");
            }
            else
            {
                // Play the voice only when the state is pressed to false
                if (canPlayVoice && !playerInteract.GetHinnagami().getVoice().isPlaying) // Check if the voice is already playing
                {
                    playerInteract.GetHinnagami().getVoice().Play();
                    StartCoroutine(VoiceCooldown()); // Start the cooldown coroutine
                }
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

    private IEnumerator VoiceCooldown()
    {
        canPlayVoice = false; // Prevent voice from playing again
        yield return new WaitForSeconds(3f); // Wait for 3 seconds
        canPlayVoice = true; // Allow voice to play again
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