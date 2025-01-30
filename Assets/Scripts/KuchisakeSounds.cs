using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KuchisakeSounds : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject kuchisakeLevel3;
    public GameObject kuchisakeLevel4;
    public GameObject kuchisakeLevel6;

    void Start()
    {
        kuchisakeLevel3.SetActive(false);
        kuchisakeLevel4.SetActive(false);
        kuchisakeLevel6.SetActive(false);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Level3Trigger"))
        {
            kuchisakeLevel3.SetActive(true);
            kuchisakeLevel4.SetActive(false);
            kuchisakeLevel6.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Level4Trigger"))
        {
            kuchisakeLevel3.SetActive(false);
            kuchisakeLevel4.SetActive(true);
            kuchisakeLevel6.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Level6Trigger"))
        {
            kuchisakeLevel3.SetActive(false);
            kuchisakeLevel4.SetActive(false);
            kuchisakeLevel6.SetActive(true);
        }
    }
}
