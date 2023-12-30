using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate1 : MonoBehaviour
{
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
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    isDragging = true;
                    dragStartMousePos = Input.mousePosition;
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector3 dragCurrentMousePos = Input.mousePosition;
            float mouseYDelta = dragCurrentMousePos.y - dragStartMousePos.y;

            float angle = mouseYDelta * 0.9f;

            transform.Rotate(Vector3.forward, angle, Space.World);
            dragStartMousePos = dragCurrentMousePos;
        }
    }

}
