using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FearVoice : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip fearVoiceSound;
    private CoinManager coinManager;
    private Player player;

    private float timeFromLastVoice;
    public float timeBetweenVoice = 60;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        coinManager = FindObjectOfType<CoinManager>();
        player = FindObjectOfType<Player>();
    }
    void Update()
    {
        timeFromLastVoice += Time.deltaTime;
        if(timeFromLastVoice < timeBetweenVoice)
        {
            return;
        }
        Coin closestCoin = coinManager.GetClosest(player.transform.position);
        float distanceToCoin = Vector3.Distance(closestCoin.transform.position, player.transform.position);

        if (distanceToCoin < 10)
        {
            audioSource.clip = fearVoiceSound;
            audioSource.Play();
            timeFromLastVoice = 0;
        }    
    }
}
