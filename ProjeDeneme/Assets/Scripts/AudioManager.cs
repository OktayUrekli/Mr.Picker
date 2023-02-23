using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] GameObject audioPanel;
    bool audioPanelOpen;
    void Start()
    {
        audioPanelOpen = false; 
        audioPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AudioLevel()
    {
        if (!audioPanelOpen)
        {
            audioPanel.SetActive(true);
            audioPanelOpen = true;
        }
        else
        {
            audioPanel.SetActive(false);
            audioPanelOpen = false;
        }
    }
}
