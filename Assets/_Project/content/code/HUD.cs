using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Inventory Inventory;
    public Transform InventoryPanel;

    // Use this for initialization
    void Start()
    {
        Inventory.ItemAdded += InventoryScript_ItemAdded;
    }

    private void InventoryScript_ItemAdded(object sender, InventoryEventArgs e)
    {
        if (InventoryPanel == null)
        {
            return;
        }

        foreach (Transform slot in InventoryPanel)
        {
            // Border... Image
            Image image = slot.GetChild(0).GetChild(0).GetComponent<Image>();
            // We found the empty slot
            if (!image.enabled)
            {
                image.enabled = true;
                image.sprite = e.Item.Image;
                break;
            }
        }
    }
}