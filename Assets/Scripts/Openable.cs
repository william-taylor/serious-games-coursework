﻿using UnityEngine;

public class Openable : MonoBehaviour
{
    public Vector3 OpenPosition;
    public Vector3 OpenRotation;

    private Vector3 closePosition;
    private Vector3 closeRotation;
    private bool isOpen = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.distance <= 2.0f && hit.collider.name == name)
                {
                    if (!isOpen)
                    {
                        OpenObject();
                    }
                    else
                    {
                        CloseObject();
                    }
                }
            }
        }
    }

    void OpenObject()
    {
        closeRotation = transform.rotation.eulerAngles;
        closePosition = transform.position;

        transform.rotation = Quaternion.Euler(OpenRotation.x, OpenRotation.y, OpenRotation.z);
        transform.localPosition = OpenPosition;

        isOpen = true;
    }

    void CloseObject()
    {
        transform.rotation = Quaternion.Euler(closeRotation.x, closeRotation.y, closeRotation.z);
        transform.localPosition = closeRotation;

        isOpen = false;
    }
}
