using UnityEngine;
using UnityEngine.UI;

public class Hint : MonoBehaviour
{
    public GameObject player;
    public GameObject hintUI;

    private bool isPlayerNear = false;

    void Start()
    {
        hintUI.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            hintUI.SetActive(true);
            isPlayerNear = true;

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            hintUI.SetActive(false);
            isPlayerNear = false;
        }
    }
}

