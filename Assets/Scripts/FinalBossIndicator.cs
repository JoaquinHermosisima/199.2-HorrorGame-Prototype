using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossIndicator : MonoBehaviour
{
    public int vertiLockOrder;
    public Material brown;
    public Material glow;
    [SerializeField] private BossKatana katBlock;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (katBlock.getCurrentAngle() == vertiLockOrder)
        {
            GetComponent<Renderer>().material = glow;
        } else {
            GetComponent<Renderer>().material = brown;
        }

    }
}

