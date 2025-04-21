using UnityEngine;
using System.Collections.Generic;
using System; 

public class iteminventory : MonoBehaviour
{
    
    [SerializeField] private int slots = 6; 

    private List<IInventoryItem> mItems = new List<IInventoryItem>();

    [SerializeField] 
    private bool _hasKey = false; 

    public bool HasKey => _hasKey; 
    public event EventHandler<InventoryEventArgs> ItemAdded; 

    public void AddItem(IInventoryItem item)
    {
        
        if (mItems.Count >= slots)
        {
            Debug.LogWarning($"ItemInventory: Inventory is full ({mItems.Count}/{slots}). Cannot add {item.Name}.", this);
            return;
        }

        MonoBehaviour itemMonoBehaviour = item as MonoBehaviour;
        if (itemMonoBehaviour == null)
        {
            Debug.LogError("ItemInventory: Item being added is not a MonoBehaviour component! Cannot check for key identifier.", this);
            return; 
        }

        if (!_hasKey)
        {
           
            KeyItemIdentifier keyIdentifier = itemMonoBehaviour.GetComponent<KeyItemIdentifier>();

            if (keyIdentifier != null)
            {
                Debug.Log(">>> ItemInventory: Security Key Picked Up! <<<");
                _hasKey = true; 
            }
        }
       
        mItems.Add(item);

        item.OnPickup();
        ItemAdded?.Invoke(this, new InventoryEventArgs(item));
        Debug.Log($"ItemInventory: Added '{item.Name}'. Total items: {mItems.Count}. HasKey: {HasKey}", this);
    }

    public bool CheckHasKey()
    {
        return HasKey;
    }

    public List<IInventoryItem> GetItems()
    {
        return mItems;
    }
}