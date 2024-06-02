using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMangaer : MonoBehaviour
{
    public static SoundMangaer instance;

    public Sound[] sfxSounds, musicSounds;
    public AudioSource musicSource, sfxSource;



    public void Start()
    {
        GameEventManager.instance.playerDead.onPlayerDead += PlayerDead_onPlayerDead;
        GameEventManager.instance.playerDmged.onPlayerDmged += PlayerDmged_onPlayerDmged;
        GameEventManager.instance.bigMtaken.onBigMtaken += BigMtaken_onBigMtaken;
        GameEventManager.instance.smallMtaken.onSmallMtaken += SmallMtaken_onSmallMtaken;
        GameEventManager.instance.enemyDestroyed.onEnemyDestroyed += EnemyDestroyed_onEnemyDestroyed;
        GameEventManager.instance.coinGain.onCoinGained += CoinGain_onCoinGained;
        GameEventManager.instance.endLevel.onEndLevel += EndLevel_onEndLevel;
        
    }

    private void EndLevel_onEndLevel()
    {
        sfxSource.PlayOneShot(sfxSounds[6].GetAudioClip());
    }

    private void CoinGain_onCoinGained()
    {
        sfxSource.PlayOneShot(sfxSounds[5].GetAudioClip());
    }

    private void EnemyDestroyed_onEnemyDestroyed()
    {
        sfxSource.PlayOneShot(sfxSounds[0].GetAudioClip());
    }

    private void SmallMtaken_onSmallMtaken()
    {
        sfxSource.PlayOneShot(sfxSounds[3].GetAudioClip());
    }

    private void BigMtaken_onBigMtaken()
    {
        sfxSource.PlayOneShot(sfxSounds[4].GetAudioClip());
    }

    private void PlayerDmged_onPlayerDmged()
    {
        sfxSource.PlayOneShot(sfxSounds[1].GetAudioClip());
    }

    private void PlayerDead_onPlayerDead()
    {
        sfxSource.PlayOneShot(sfxSounds[2].GetAudioClip());
    }
}
