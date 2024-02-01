using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    private float moveSpeed = 5.0f;
    private float zoomSpeed = 5.0f;

    private float minX = -5.0f;
    private float maxX = 30.0f;
    private float minY = 10.0f;
    private float maxY = 15.0f;
    public float minZoom = 1.0f;
    public float maxZoom = 5.0f;

    private bool isDragging = false;
    private Vector3 lastMousePosition;

    void Update()
    {
        HandleDragInput();
        HandleZoomInput();
    }

    void HandleDragInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            lastMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector3 deltaMouse = Input.mousePosition - lastMousePosition;

            float moveX = deltaMouse.x * moveSpeed * Time.deltaTime;
            float moveY = deltaMouse.y * moveSpeed * Time.deltaTime;

            float newX = Mathf.Clamp(transform.position.x + moveX, minX, maxX);
            float newY = Mathf.Clamp(transform.position.y + moveY, minY, maxY);

            transform.position = new Vector3(newX, newY, transform.position.z);

            lastMousePosition = Input.mousePosition;
        }
    }

    void HandleZoomInput()
    {
        float zoomValue = Input.GetAxis("Mouse ScrollWheel");

        if (zoomValue != 0)
        {
            float newZoom = Mathf.Clamp(transform.position.y - zoomValue * zoomSpeed, minY, maxY);
            transform.position = new Vector3(transform.position.x, newZoom, transform.position.z);

            // Mouse pozisyonuna doðru hareket etme (zoom in & out)
            if (Input.GetMouseButton(1)) // 1 numaralý mouse butonu (sað týklama)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    Vector3 targetPosition = new Vector3(hit.point.x, hit.point.y, transform.position.z);
                    transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * zoomSpeed);
                }
            }
        }
    }
}
