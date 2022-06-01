using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{
    public enum ItemType
    {
        Syringe, //healing item
        Bullets,
    }

    public ItemType itemType;
    public int amount;
}
