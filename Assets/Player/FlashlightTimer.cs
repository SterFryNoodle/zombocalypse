using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightTimer : MonoBehaviour
{
    [SerializeField] float lightDecay = .1f;
    [SerializeField] float angleDecay = 1f;
    
    Light flashLight;
    void Start()
    {
        flashLight = GetComponent<Light>();
    }

    
    void Update()
    {
        DecreaseLightIntensity();
        DecreaseLightAngle();
    }

    void DecreaseLightIntensity()
    {
        if (flashLight.intensity > 0)
        {
            flashLight.intensity -= lightDecay * Time.deltaTime;            
        }        
    }

    void DecreaseLightAngle()
    {
        if (flashLight.spotAngle >= flashLight.innerSpotAngle)
        {
            flashLight.spotAngle -= angleDecay * Time.deltaTime;
        }
    }
}
