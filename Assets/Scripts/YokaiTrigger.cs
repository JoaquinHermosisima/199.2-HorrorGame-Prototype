using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class YokaiTrigger : MonoBehaviour
{
    [SerializeField] private GameObject yokai;

    public bool notebookNotUsable = false;

    private void OnTriggerEnter(Collider other)
    {
        notebookNotUsable = true;
        Debug.Log("I am Colliding");
    }

    public bool returnNotebookStatus() 
    {
        return notebookNotUsable;
    }
}
