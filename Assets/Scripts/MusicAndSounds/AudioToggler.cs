using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioToggled : MonoBehaviour
{
    public bool isOn;
    public GameObject soundObj;
    private void Start()
    {
        soundObj = GameObject.FindGameObjectWithTag("SoundManager");
        isOn = true;
    }

    public void OnOffSounds()
    {
        if (!isOn)
        {
            soundObj.SetActive(true);
            isOn = true;
        }
        else
        {
            soundObj.SetActive(false);
            isOn = false;
        }
    }
}