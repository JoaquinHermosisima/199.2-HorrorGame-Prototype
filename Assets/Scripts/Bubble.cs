using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.VersionControl;

public class Bubble : MonoBehaviour
{
    public static void Create(Transform parent, Vector3 localposition, string text)
    {
        Transform bubbleTransform = Instantiate(GameAssets.i.pfChatBubble)
    }
}
