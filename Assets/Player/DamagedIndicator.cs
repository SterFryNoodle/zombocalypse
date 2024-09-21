using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagedIndicator : MonoBehaviour
{
    [SerializeField] Canvas takeDmgCanvas;
    [SerializeField] float impactTimer = 0.3f;

    void Start()
    {
        takeDmgCanvas.enabled = false;
    }
        
    public void ShowDamageUI()
    {
        StartCoroutine(ShowStatic());
    }

    IEnumerator ShowStatic()
    {        
        takeDmgCanvas.enabled = true;        
        yield return new WaitForSeconds(impactTimer);
        takeDmgCanvas.enabled = false;
    }
}
