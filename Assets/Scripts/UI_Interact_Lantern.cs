using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Interact_Lantern : MonoBehaviour
{
    [SerializeField] private Player_Interact playerInteract;
    [SerializeField] private PlayerLight playerLight;
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject lantern;
    [SerializeField] private TMP_Text textDisplay;
    private string displayText;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playerInteract.GetLantern() != null) {
            if (playerLight.getObtained() == false)
            {
                displayText = "Press X to Obtain Lantern";
            }
            else
            {
                displayText = "Lantern Obtained\nPress F to Use";
                
            }
            textDisplay.SetText(displayText);
            Show();
        } else
        {
            Hide();
        }
    }
    private void Show()
    {
        canvas.SetActive(true);
    }

    private void Hide()
    {
        canvas.SetActive(false);
    }
}
