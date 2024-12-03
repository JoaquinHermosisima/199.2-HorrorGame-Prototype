using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class YokaiTrigger : MonoBehaviour
{
    [SerializeField] private GameObject yokai;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            yokai.SetActive(true);
        }
    }
}
