using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerZoom : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera cameraZoom;
    [SerializeField] float zoomIn = 20f;
    [SerializeField] float zoomOut = 60f;

    bool zoomInToggle = false;
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (zoomInToggle == false)
            {
                zoomInToggle = true;
                cameraZoom.m_Lens.FieldOfView = zoomIn;
            }            
        }
        else if (Input.GetMouseButtonUp(1))
        {        
            if (zoomInToggle == true)
            {
                zoomInToggle = false;
                cameraZoom.m_Lens.FieldOfView = zoomOut;
            }            
        }
    }
}
