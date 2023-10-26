using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item
{
    [SerializeField] Sprite sprite;
    public abstract void Use();
    public abstract void Pickup();
    public abstract Sprite GetSprite();
}
