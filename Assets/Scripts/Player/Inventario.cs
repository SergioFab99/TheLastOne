using Microsoft.Unity.VisualStudio.Editor;
using NUnit.Framework.Constraints;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Inventario : MonoBehaviour
{
    //Logic
    Item[] Slots;
    //UI
    [SerializeField] GameObject UISlot1;
    [SerializeField] GameObject UISlot2;
    [SerializeField] GameObject UISlot3;
    private void Awake()
    {
        Slots = new Item[3];
        Slots[0] = new Jernga();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UpdateUI();
        }
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            UseItem(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            UseItem(1);

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            UseItem(2);
        }
    }

    void Pickup(GameObject Item)
    {
        Item.gameObject.GetComponent<ItemManager>().OnPickup();
    }

    void UseItem(int n)
    {
        Slots[n].Use();

    }
    void UpdateUI()
    {
        UISlot1.GetComponent<UnityEngine.UI.Image>().sprite = Slots[0].GetSprite();
        UISlot2.GetComponent<UnityEngine.UI.Image>().sprite = Slots[1].GetSprite();
        UISlot3.GetComponent<UnityEngine.UI.Image>().sprite = Slots[2].GetSprite();
    }

    private void ClearSpace()
    {

        UpdateUI();
    }

}
