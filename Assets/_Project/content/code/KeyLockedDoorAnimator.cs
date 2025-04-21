using UnityEngine;

public class KeyLockedDoorAnimator : MonoBehaviour
{
    public Animator doorAnimator; 
    public string openAnimationTrigger = "Open"; 
    public float triggerDistance = 3f; 
    public Transform player; 
    public iteminventory playerInventory; 

    private bool isLocked = true; 

    void Start()
    {
       
        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
            {
                player = playerObj.transform;   
            }
           
        }
        if (playerInventory == null)
        {
            if (player != null)
            {
                playerInventory = player.GetComponent<iteminventory>();
            }
           
        }
    }

    void Update()
    {
        if (!isLocked || doorAnimator == null || player == null || playerInventory == null)
        {
            return;
        }
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= triggerDistance && playerInventory.HasKey) 
        {
            UnlockAndOpenDoor();
        }
    }

    void UnlockAndOpenDoor()
    {
        isLocked = false;

        if (!string.IsNullOrEmpty(openAnimationTrigger))
        {
            doorAnimator.SetTrigger(openAnimationTrigger);
        }

    }

}