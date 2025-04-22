using UnityEngine;
using System.Collections.Generic;
using System;

public class SlidingDoor : MonoBehaviour
{
    public Transform leftDoor;
    public Transform rightDoor;
    public Vector3 leftOpenOffset;
    public Vector3 rightOpenOffset;

    public float openSpeed = 2f;
    public Transform player;
    public float triggerDistance = 5f;

    private Vector3 leftClosedPos;
    private Vector3 rightClosedPos;
   
   

    void Start()
    {
        leftClosedPos = leftDoor.position;
        rightClosedPos = rightDoor.position;
    
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        bool shouldOpen = distance < triggerDistance;

        Vector3 leftTarget = shouldOpen ? leftClosedPos + leftOpenOffset : leftClosedPos;
        Vector3 rightTarget = shouldOpen ? rightClosedPos + rightOpenOffset : rightClosedPos;

       
        leftDoor.position = Vector3.Lerp(leftDoor.position, leftTarget, Time.deltaTime * openSpeed);
        rightDoor.position = Vector3.Lerp(rightDoor.position, rightTarget, Time.deltaTime * openSpeed);
      

    }
}
