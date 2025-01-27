using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossKatana : MonoBehaviour
{
    //This class is for the Katana
    public int currentAngle = 0;
    private readonly int[] angles = { 0, 70, 155, 240, 335 };

    public void Rotate()
    {
        currentAngle = (currentAngle + 1) % angles.Length;
        int nextAngle = angles[currentAngle];
        transform.rotation = Quaternion.Euler(0, nextAngle, 0);
    }

    public int getCurrentAngle()
    {
        return currentAngle;
    }
}
