using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class Jernga : Item
{
    Sprite sprite = Resources.Load<Sprite>("Jeringa");
    public override void Use()
    {
        Debug.Log("Usaste Jeringa");
    }
    public override void Pickup()
    {
        //sprite = Resources.Load<Sprite>("Assets/Sprites/Jeringa.png");
    }
    public override Sprite GetSprite()
    {
        return sprite;
    }
}