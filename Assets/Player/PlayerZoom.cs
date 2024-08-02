using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;

public class PlayerZoom : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera cameraZoom;    
    [SerializeField] float zoomIn = 20f;
    [SerializeField] float zoomOut = 60f;
    [SerializeField] float increaseSensitivity = 2f;
    [SerializeField] float decreaseSensitivity = 0.5f;

    bool zoomInToggle = false;
    FirstPersonController mouseSensitivity;
    void Start()
    {
        mouseSensitivity = GetComponent<FirstPersonController>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // decreases FOV & rotation speed.
        {
            if (zoomInToggle == false)
            {
                zoomInToggle = true;
                cameraZoom.m_Lens.FieldOfView = zoomIn;
                mouseSensitivity.RotationSpeed = decreaseSensitivity;
            }            
        }
        else if (Input.GetMouseButtonUp(1))
        {        
            if (zoomInToggle == true) // defaults FOV & player rotation speed.
            {
                zoomInToggle = false;
                cameraZoom.m_Lens.FieldOfView = zoomOut;
                mouseSensitivity.RotationSpeed = increaseSensitivity;
            }            
        }
    }
}
