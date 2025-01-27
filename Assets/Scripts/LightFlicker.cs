using System.Collections;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public Light lightSource; // Reference to the Light component
    public float flickerDuration; // Duration of each flicker
    public float flickerInterval; // Interval between flickers

    private void Update()
    {
        // Start the flickering coroutine
        StartCoroutine(FlickerLight());
    }

    private IEnumerator FlickerLight()
    {
        while (true)
        {
            // Wait for the specified interval
            yield return new WaitForSeconds(flickerInterval);

            // Flicker the light
            StartCoroutine(Flicker());
        }
    }

    private IEnumerator Flicker()
    {
        // Store the original intensity
        float originalIntensity = lightSource.intensity;

        // Flicker the light a few times
        for (int i = 0; i < 2; i++)
        {
            // Turn off the light
            lightSource.intensity = 0;
            yield return new WaitForSeconds(flickerDuration);
            Debug.Log("I am flickering");

            // Restore the original intensity
            lightSource.intensity = 1;
            yield return new WaitForSeconds(flickerDuration);
        }
    }
}