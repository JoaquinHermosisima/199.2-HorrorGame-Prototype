using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossKatanaTable : MonoBehaviour
{
    // Start is called before the first frame update
    public BossKatana katana;
    public void rotateKatana()
    {
        katana.Rotate();
    }
}
