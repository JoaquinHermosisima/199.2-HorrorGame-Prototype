using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_BossKatana : MonoBehaviour
{
    [SerializeField] private Player_Interact playerInteract;
    [SerializeField] private GameObject containerGameObject;
    void Start()
    {

    }

    void Update()
    {
        if (playerInteract.GetBossKatana() != null)
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
