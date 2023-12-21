using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public GameObject coinPrefab;
    public List<Coin> coinList = new List<Coin>();
    public int initialCoin = 50;
    public TMP_Text coinsText;
    public GameObject bloodMark;
    private GameObject blood;
    private AudioController audioController;
    void Start()
    {
        audioController = FindObjectOfType<AudioController>();
        for (int i = 0; i < 50; i++)
        {
            Vector3 position = new Vector3(Random.Range(-20, 20), 0.2f, Random.Range(-20, 20));
            GameObject newCoin = Instantiate(coinPrefab, position, Quaternion.identity);
            coinList.Add(newCoin.GetComponent<Coin>());
        }
        UpdateText();
    }
    public void CollectCoin(Coin coin)
    {       
        blood = Instantiate(bloodMark, new Vector3(coin.transform.position.x,0.83f, coin.transform.position.z), coin.transform.rotation);
        blood.transform.position = new Vector3(coin.transform.position.x,-0.489f, coin.transform.position.z);
        UpdateText();
        coinList.Remove(coin);
        Destroy(coin.gameObject);

        audioController.PlayDeathSound();
    }
    private void UpdateText()
    {
        coinsText.text = "залишилося зібрати монет:" + coinList.Count.ToString();
    }
    public Coin GetClosest(Vector3 point)
    {
        float minDistance = Mathf.Infinity;
        Coin closestCoin = null;
        for (int i = 0; i < coinList.Count; i++)
        {
            float distance = Vector3.Distance(point, coinList[i].transform.position);
            if(distance < minDistance)
            {
                minDistance = distance;
                closestCoin = coinList[i];
            }
        }
        return closestCoin;
    }
}
