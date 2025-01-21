using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_CabLock : MonoBehaviour
{
    [SerializeField] private Player_Interact playerInteract;
    [SerializeField] private GameObject containerGameObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInteract.GetCabDetect() != null) {
            Show();
        } else
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
