using UnityEngine;
using UnityEngine.UI;

public class win : MonoBehaviour
{
    public Animator anim;
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

        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("box Opened!");
            anim.SetBool("open", true);
        }
       
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
