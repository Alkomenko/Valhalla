using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioToggled : MonoBehaviour
{
    public bool isOn;

    private void Start()
    {
        isOn = true;
    }

    public void OnOffSounds()
    {
        if (!isOn)
        {
            AudioListener.volume = 1f;
            isOn = true;
        }
        else
        {
            AudioListener.volume = 0f;
            isOn = false;
        }
    }
}
