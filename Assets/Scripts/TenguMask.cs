using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TenguMask : MonoBehaviour
{
    public AudioSource tenguVoice;

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            tenguVoice.Play();
        }
    }
}
