using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katana : MonoBehaviour
{
    //This class is for the Katana
    private int currentAngle = 0;
    private readonly int[] angles = { 90, 180, 270, 360 };

    public void Rotate()
    {
        currentAngle = (currentAngle + 1) % angles.Length;
        int nextAngle = angles[currentAngle];
        transform.rotation = Quaternion.Euler(0, nextAngle, 0);
    }
}
