using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public CoinManager coinManager;
    private Transform playerTransform;
    public float rotationSpeed = 3f;

    private void Start()
    {
        playerTransform = FindObjectOfType<Player>().transform;
    }
    private void Update()
    {
        transform.position = playerTransform.position;

        Coin closestCoin = coinManager.GetClosest(transform.position);

        Vector3 toTarget = closestCoin.transform.position;
        Vector3 totargetXZ = new Vector3(toTarget.x,transform.position.y, toTarget.z);
        Vector3 direction = totargetXZ - transform.position;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotationSpeed);

    }
}