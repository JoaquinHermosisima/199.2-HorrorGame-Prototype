using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class YokaiTrigger : MonoBehaviour
{
    [SerializeField] private GameObject yokai;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("FloorTrigger")) // Ensure the player has the "Player" tag
        {
            Debug.Log("I am stepping");
        }
    }
}
