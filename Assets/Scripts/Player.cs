using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CoinManager coinManager;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("true1312");
        if (other.GetComponent<Coin>())
        {
            Debug.Log("true");
            coinManager.CollectCoin(other.GetComponent<Coin>());
        }
    }
}
