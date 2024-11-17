using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Parent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckCollisions();
    }

    void CheckCollisions()
    {
        // Get all components of type YourPlatformComponent in the children
        Block_Platform[] platformComponents = GetComponentsInChildren<Block_Platform>();

        foreach (Block_Platform platform in platformComponents)
        {
            bool isColliding = platform.getColliding();
            Debug.Log($"{platform.name} is colliding: {isColliding}");
        }
    }
}
