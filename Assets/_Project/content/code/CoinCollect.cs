using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;


public class CoinCollect : MonoBehaviour
{
    private int Coin = 0;
   
    public TextMeshProUGUI coinText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Coin")
        {
            Coin++;
            coinText.text = "Coins" +" "+ Coin.ToString();
            Destroy(other.gameObject);

        }
        
    }
}
