using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioClip[] sounds;
    public static bool CheckVolumeButton = true;
    public static bool CheckMusicButton = true;
    private AudioSource audioSrc => GetComponent<AudioSource>();
    public void OnClick()
    {
        audioSrc.PlayOneShot(sounds[0], 1f);
    }
}
