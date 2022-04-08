using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class settingsmenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    private void Start()
    {
        SetVolume(0.5f);
    }

    public void SetVolume (float value)
    {
        audioMixer.SetFloat("Volume", Mathf.Log(value) * 20f);
    }
    
    public void SetFullscreen (bool isFullscreeen)
    {
        Screen.fullScreen = isFullscreeen;
    }
}
