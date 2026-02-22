using System;
using UnityEngine;

public class PlayerFlip : MonoBehaviour
{
    private InputHandler input;
    private Camera mainCamera;

    [SerializeField] private Transform graphicsTransform;

    void Start()
    {
        input = GetComponent<InputHandler>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        FlipTowardsMouse();
    }

    void FlipTowardsMouse()
    {
        // Convert Mouse Position from Screen Space to World Space
        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(input.MousePosition);

        // Check if the mouse is to the left or right of the player
        if (mouseWorldPos.x < transform.position.x)
        {
            // Look Left
            graphicsTransform.localScale = new Vector3(-1, 1, 1);
        }
        else if (mouseWorldPos.x > transform.position.x)
        {
            // Look Right
            graphicsTransform.localScale = new Vector3(1, 1, 1);
        }
    }
}