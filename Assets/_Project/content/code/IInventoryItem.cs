using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventoryItem
{
    string Name { get; }
    Sprite Image { get; }
    void OnPickup();
}

public class InventoryEventArgs : EventArgs
{
    public IInventoryItem Item { get; private set; }

    public InventoryEventArgs(IInventoryItem item)
    {
        Item = item;
    }
}