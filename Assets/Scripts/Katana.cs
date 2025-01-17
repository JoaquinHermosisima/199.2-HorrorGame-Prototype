using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katana : MonoBehaviour
{
    //This class is for the Katana
    public int currentAngle = 0;
    private readonly int[] angles = {0, 70, 130, 155, 180, 240, 310, 335};
    public bool isCorrect = false;
    [SerializeField] public int correctAngle;
    private void Start()
    {

    }
    public void Update()
    {
        if(angles[currentAngle] == correctAngle)
        {
            isCorrect = true;
        } else
        {
            isCorrect = false;
        }
    }
    public void Rotate()
    {
        currentAngle = (currentAngle + 1) % angles.Length;
        int nextAngle = angles[currentAngle];
        transform.rotation = Quaternion.Euler(0, nextAngle, 0);
    }

    public bool GetIsCorrect()
    {
        return isCorrect;
    }
}
