using System.Collections;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public Light myLight;
    public float interval = 0.1f;

    float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > interval)
        {
            myLight.enabled = !myLight.enabled;
            timer -= interval;
        }
    }
}