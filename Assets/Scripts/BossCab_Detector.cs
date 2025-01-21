using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCab_Detector : MonoBehaviour
{
    // Start is called before the first frame update
    public BossCab_Lock cube;

    // Update is called once per frame
    public void rotateLock()
    {
        cube.rotate();
    }
}
