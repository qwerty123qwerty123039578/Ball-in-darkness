using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isLose = false;
    private LightControl[] allLightes;
    public static GameManager instance = null;
    private AudioController audioController;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance == this)
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        allLightes = FindObjectsOfType<LightControl>();
        audioController = FindObjectOfType<AudioController>();
    }
    public void Lose()
    {
        isLose = true;
        foreach(LightControl light in allLightes)
        {
            light.GetComponent<Light>().enabled = false;
        }
        audioController.PlayLooseSound();
    }
    public void RestartGame()
    {
        isLose = false;
        foreach (LightControl light in allLightes)
        {
            light.GetComponent<Light>().enabled = true;
        }
    }
}
