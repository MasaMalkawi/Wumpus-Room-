using UnityEngine;

public class RightDoor : MonoBehaviour
{
    public Transform rightDoor;
    public Vector3 rightOpenOffset;

    public float openSpeed = 2f;
    public Transform player;
    public float triggerDistance = 5f;

    private Vector3 rightClosedPos;

    void Start()
    {
        rightClosedPos = rightDoor.position;
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        bool shouldOpen = distance < triggerDistance;

        Vector3 rightTarget = shouldOpen ? rightClosedPos + rightOpenOffset : rightClosedPos;

        rightDoor.position = Vector3.Lerp(rightDoor.position, rightTarget, Time.deltaTime * openSpeed);
    }
}