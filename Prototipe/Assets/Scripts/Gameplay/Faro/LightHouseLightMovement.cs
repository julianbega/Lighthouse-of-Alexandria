using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightHouseLightMovement : MonoBehaviour
{
    private Vector3 mousePosition;
    public float moveSpeed = 0.1f;
    private Camera mainCamera;
    private Vector3 pos;
    private void Start()
    {
        mainCamera = Camera.main;
    }
    void Update()
    {
        mousePosition = Input.mousePosition;
        Ray ray = mainCamera.ScreenPointToRay(mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            pos = new Vector3(raycastHit.point.x, transform.position.y, raycastHit.point.z);
        }
        transform.position = Vector3.Lerp(transform.position, pos, moveSpeed);
    }
}
