using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableTextureMove : MonoBehaviour
{
    [SerializeField] Transform underGroundBuilding;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            underGroundBuilding.GetComponent<MoveTexture>().enabled = true;
        }        
    }
}
