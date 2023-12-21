using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControl : MonoBehaviour
{
    private Transform player;
    public Transform ground;
    private Light myLight;
    public Color goodColor;
    public Color badColor;
    void Start()
    {
        player = FindObjectOfType<Player>().transform;
        myLight = GetComponent<Light>();
    }
    void Update()
    {
        ChangeLightColor();
    }
    void ChangeLightColor()
    {
        float DistanceToBound = GetMinDistanceToBound();
        float t = Mathf.InverseLerp(0,ground.localScale.x/2,DistanceToBound);
        myLight.color = Color.Lerp(goodColor, badColor,t);
    }
    float GetMinDistanceToBound()
    {
        float zBound = ground.position.z + ground.localScale.z / 2;
        float xBound = ground.position.x + ground.localScale.x / 2;
        float minDistance = Mathf.Min(player.position.x + xBound, xBound - player.position.x,player.position.z + zBound,zBound = player.position.z);
        return minDistance;
    }
}
