using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hinnagami : MonoBehaviour
{
    public GameObject hint;
    public AudioSource hinaVoice;
    // Update is called once per frame

    public AudioSource getVoice()
    {
        return hinaVoice;
    }
    public GameObject getHint()
    {
        return hint;
    }

    public void hintOpen()
    {
        hint.SetActive(true);
    }

    public void hintClose()
    {
        hint.SetActive(false);
    }

}
