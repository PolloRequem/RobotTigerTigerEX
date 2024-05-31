using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSurceButton : MonoBehaviour
{
    public AudioSource audioSource;
    public static AudioSurceButton Instance;
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound()
    {
        audioSource.Play();
    }
}
