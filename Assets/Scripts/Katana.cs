using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katana : MonoBehaviour
{
    //This class is for the Katana
    private int currentAngle = 0;
    private readonly int[] angles = { 0, 70, 130, 155, 180, 240, 310, 335};
    public Material currentMaterial;
    public Material greenGlow;
    [SerializeField] private KatanaTable table;
    [SerializeField] private int correctAngle;

    private void Update()
    {
        if(angles[currentAngle] == correctAngle)
        {
            table.GetComponent<Renderer>().material = greenGlow;
        } else
        {
            table.GetComponent<Renderer>().material = currentMaterial;
        }
    }
    public void Rotate()
    {
        currentAngle = (currentAngle + 1) % angles.Length;
        int nextAngle = angles[currentAngle];
        transform.rotation = Quaternion.Euler(0, nextAngle, 0);
    }
}
