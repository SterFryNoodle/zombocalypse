using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerZoom : MonoBehaviour
{    
    [SerializeField] float zoomAmount;
    [SerializeField] float zoomIn = 40f;
    [SerializeField] float zoomOut = 40f;

    void Start()
    {        
        zoomAmount = GetComponent<Camera>().fieldOfView;
    }
    
    void Update()
    {
        
    }
}
