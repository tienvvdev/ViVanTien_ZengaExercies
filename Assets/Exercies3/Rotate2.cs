using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate2 : MonoBehaviour
{
    public float rotationSpeed = 5f;

    private Camera mainCamera;
    private bool isDragging = false;
    private Vector3 dragStartMousePos;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            dragStartMousePos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector3 dragCurrentMousePos = Input.mousePosition;
            float mouseXDelta = dragCurrentMousePos.x - dragStartMousePos.x;

            float angle = -mouseXDelta * rotationSpeed * Time.deltaTime;

            transform.Rotate(Vector3.up, angle, Space.World);

            dragStartMousePos = dragCurrentMousePos;
        }
    }
}
