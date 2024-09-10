using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTexture : MonoBehaviour
{
    Renderer rend;
    [SerializeField] float speed = 1.0f;
    [SerializeField] float lerpValue;
        
    Vector2 startOffset;
    Vector2 endOffset;
    void Start()
    {
        if (rend == null)
        {
            rend = GetComponent<Renderer>();
        }
                
        startOffset = rend.material.GetTextureOffset("_BaseMap");
        endOffset = new Vector2(2f, 2f);
    }
    
    void Update()
    {
        lerpValue = Mathf.PingPong(Time.time * speed, 1.0f);

        Vector2 newOffset = Vector2.Lerp(startOffset, endOffset, lerpValue);
        rend.material.SetTextureOffset("_BaseMap", newOffset);

        if (lerpValue > 1.0f)
        {
            lerpValue = 0f;
        }
    }
}
