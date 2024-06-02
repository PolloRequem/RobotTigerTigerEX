using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    private bool isPausaAttivata = false;
    private  bool sfxAttivato = true;
    private  bool musicAttivato = true;
    [SerializeField] private GameObject GO_PauseMenu;
    [SerializeField] private Toggle musicToggle;
    [SerializeField] private Toggle sfxToggle;
    [SerializeField] private Toggle fullScreenToggle;

    [SerializeField] private AudioSource sfxAudioSurce;
    [SerializeField] private AudioSource musicSource;






    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPausaAttivata)
            {
                DisattivaPausa();
            }
            else
            {
                AttivaPausa();
            }
        }
    }


    private void AttivaPausa()
    {
        sfxToggle.isOn = sfxAttivato;
        musicToggle.isOn = musicAttivato;
        fullScreenToggle.isOn = Screen.fullScreen;
        GO_PauseMenu.SetActive(true);
        isPausaAttivata = true;
        Time.timeScale = 0f;
     
    }

    private void DisattivaPausa()
    {
        sfxToggle.isOn = sfxAttivato;
        musicToggle.isOn = musicAttivato;
        fullScreenToggle.isOn = Screen.fullScreen;
        GO_PauseMenu.SetActive(false);
        isPausaAttivata = false;
        Time.timeScale = 1f;
     
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetMusic(bool isMusic)
    {
        if (isMusic) { musicSource.volume = 0.3f; } else { musicSource.volume = 0f; }
       
        musicAttivato = isMusic;
    }

    public void SetSFX(bool isSFX)
    {
        sfxAudioSurce.enabled = isSFX;
        sfxAttivato = isSFX;
    }

}
