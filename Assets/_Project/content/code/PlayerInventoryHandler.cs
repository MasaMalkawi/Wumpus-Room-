using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerInventoryHandler : MonoBehaviour
{
    public iteminventory inventory;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        IInventoryItem item = hit.collider.GetComponent<IInventoryItem>();
        if (item != null)
        {
            inventory.AddItem(item);
           
        }
    }
}