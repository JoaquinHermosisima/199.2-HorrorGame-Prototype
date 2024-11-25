using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatanaTable : MonoBehaviour
{
    //This class is for the player to detect when to rotate the Katana
    public Katana katana;

    // Update is called once per frame
    public void rotateKatana()
    {
        katana.Rotate();
    }
}
