using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class settingsmenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    private void Start()
    {
        SetVolume(.0f);
    }

    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
    
    public void SetFullscreen (bool isFullscreeen)
    {
        Screen.fullScreen = isFullscreeen;
    }
     
    
}
