using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound 
{
    public string name;
    public AudioClip audioClip;


    public AudioClip GetAudioClip()
    {
        return audioClip;
    }
}
