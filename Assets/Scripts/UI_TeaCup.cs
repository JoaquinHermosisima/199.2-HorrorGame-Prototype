using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_TeaCup : MonoBehaviour
{
    [SerializeField] private Player_Interact playerInteract;
    [SerializeField] private GameObject containerGameObject;
    void Start()
    {
        
    }

    void Update()
    {

        if (playerInteract.getTeacup() != null)
        {
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
