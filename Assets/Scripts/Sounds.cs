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

    public void PlaySound(AudioClip clip, 
                            bool destroyed = false, 
                            float p1 = 0.85f, 
                            float p2 = 1.2f)
    {
        // audioSrc.pitch = Random.Range(p1, p2);
        if (CheckVolumeButton == true)
        {
            audioSrc.PlayOneShot(clip, 1f);
        }
        if (CheckVolumeButton == false)
        {
            audioSrc.PlayOneShot(clip, 0f);
        }
        
        // audioSrc.PlayOneShot(clip, volume);
    }
    
    public void ResetVolumeButton()
    {
        audioSrc.PlayOneShot(sounds[0], 1f);
        if (CheckVolumeButton)
        {
            CheckVolumeButton = false;
        }
        else
        {
            CheckVolumeButton = true;
        }
    }

    public void ResetMusicButton()
    {
        PlayMusic(sounds[0]);
        if (CheckMusicButton)
        {
            CheckMusicButton = false;
        }
        else
        {
            CheckMusicButton = true;
        }
    }
    
    public void PlayMusic(AudioClip clip, 
        bool destroyed = false, 
        float p1 = 0.85f, 
        float p2 = 1.2f)
    {
        if (CheckMusicButton == true)
        {
            audioSrc.PlayOneShot(clip, 1f);
        }
        if (CheckMusicButton == false)
        {
            audioSrc.Stop();
            // audioSrc.PlayOneShot(clip, 0f);
            //audioSrc.IsDestroyed();
        }
    }
}
