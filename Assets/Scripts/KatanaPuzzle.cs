/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatanaPuzzle : MonoBehaviour
{
    public GameObject RoChar;
    public GameObject TeaPuzzle;
    [SerializeField] private AudioSource roSound;
    [SerializeField] private Katana[] katanas;
    private bool allMatch;
    // Start is called before the first frame update
    void Start()
    {
        allMatch = false;
        RoChar.SetActive(false);
        TeaPuzzle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        checkTables();
    }

    void checkTables()
    {
        allMatch = true;
        foreach (Katana katana in katanas)
        {
            if (katana.GetIsCorrect() == false)
            {
                allMatch = false;
                break;
            }
        }

        if (allMatch)
        {
            RoChar.SetActive(true);
            TeaPuzzle.SetActive(true);
            roSound.Play();
        }
    }
}*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatanaPuzzle : MonoBehaviour
{
    public GameObject RoChar;
    public GameObject TeaPuzzle;
    [SerializeField] private AudioSource roSound;
    [SerializeField] private Katana[] katanas;
    private bool allMatch;
    private bool soundPlayed; // Flag to track if the sound has been played

    // Start is called before the first frame update
    void Start()
    {
        allMatch = false;
        soundPlayed = false; // Initialize the soundPlayed flag to false
        RoChar.SetActive(false);
        TeaPuzzle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        checkTables();
    }

    void checkTables()
    {
        allMatch = true;
        foreach (Katana katana in katanas)
        {
            if (!katana.GetIsCorrect())
            {
                allMatch = false;
                break;
            }
        }

        if (allMatch && !soundPlayed) // Check if all match and sound hasn't been played
        {
            RoChar.SetActive(true);
            TeaPuzzle.SetActive(true);
            roSound.Play();
            soundPlayed = true; // Set the flag to true to prevent replaying
        }
    }
}
