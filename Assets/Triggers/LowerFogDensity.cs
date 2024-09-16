using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerFogDensity : MonoBehaviour
{
    [SerializeField] float reductionSpeed = 5f;
    [SerializeField] float minimumFogEndDistance = 90f;

    bool isReducingFog = false;
    void Update()
    {
        if (isReducingFog && RenderSettings.fogEndDistance <= minimumFogEndDistance)
        {
            RenderSettings.fogEndDistance += reductionSpeed * Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isReducingFog = true; 
        }
    }
}
