using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katana : MonoBehaviour
{
    //This class is for the Katana
    private int currentAngle = 0;
    private readonly int[] angles = { 45, 90, 135, 180, 225, 270, 315, 360 };

    public void Rotate()
    {
        currentAngle = (currentAngle + 1) % angles.Length;
        int nextAngle = angles[currentAngle];
        transform.rotation = Quaternion.Euler(0, nextAngle, 0);
    }
}
