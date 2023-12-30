using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInputRaycasst : MonoBehaviour
{
    public Camera mainCamera;
    public Transform cubeTransform;
    public Transform planeTransform;

    private bool isDragging = false;
    private Plane dragPlane;
    private Vector3 offset;

    void Start()
    {
        dragPlane = new Plane(planeTransform.up, planeTransform.position);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartDragging();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopDragging();
        }

        if (isDragging)
        {
            UpdateDragging();
        }
    }

    void StartDragging()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        float rayDistance;

        if (dragPlane.Raycast(ray, out rayDistance))
        {
            isDragging = true;
            offset = cubeTransform.position - ray.GetPoint(rayDistance);
        }
    }

    void StopDragging()
    {
        isDragging = false;
    }

    void UpdateDragging()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        float rayDistance;

        if (dragPlane.Raycast(ray, out rayDistance))
        {
            cubeTransform.position = ray.GetPoint(rayDistance) + offset;
        }
    }
}
