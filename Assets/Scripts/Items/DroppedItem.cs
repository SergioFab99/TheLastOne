using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedItem : MonoBehaviour
{
    public bool ispickable;
    SpriteRenderer spriteRenderer;
    Inventario inventario;
    [SerializeField] Item ItemDropped;

    void Start()
    {
        inventario = GameObject.Find("Player").GetComponent<Inventario>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        ItemDropped = new Jernga();
    }

    // Update is called once per frame
    void Update()
    {
        if(ispickable)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Test Pickup");
                inventario.PickupItem(new Jernga());
                Destroy(gameObject);
            }
        }
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
