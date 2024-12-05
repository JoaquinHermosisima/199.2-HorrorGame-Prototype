using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hinnagami : MonoBehaviour
{
    public string hint;
    public AudioSource hinaVoice;
    // Update is called once per frame

    public AudioSource getVoice()
    {
        return hinaVoice;
    }
    public string getHint()
    {
        return hint;
    }

}
