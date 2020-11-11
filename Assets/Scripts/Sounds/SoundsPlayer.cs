using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundsPlayer : MonoBehaviour
{
    SoundsController soundsController;

    void Awake()
    {
        soundsController = FindObjectOfType<SoundsController>();
    }
    
    public void PlayOnce(string _soundName)
    {
        soundsController.PlayOnce(_soundName);
    }

    public void PlayOneShot(string _soundName)
    {
        soundsController.PlayOneShot(_soundName);
    }
}
