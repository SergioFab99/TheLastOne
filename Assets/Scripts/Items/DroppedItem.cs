using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedItem : MonoBehaviour
{
    public bool ispickable;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetPickAble()
    {
        ispickable = true;
        spriteRenderer.color = Color.green;
    }
    public void SetUnpickAble()
    {
        ispickable = false;
        spriteRenderer.color = Color.white;
    }
    
}
