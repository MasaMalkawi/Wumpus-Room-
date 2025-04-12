using UnityEngine;

public class Key : MonoBehaviour, IInventoryItem
{
    public string Name => "Key";
    public Sprite _Image;
    public Sprite Image => _Image;

    public void OnPickup()
    {
        gameObject.SetActive(false);
    }
}