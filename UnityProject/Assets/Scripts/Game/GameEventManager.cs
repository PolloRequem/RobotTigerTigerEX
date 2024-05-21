using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventManager : MonoBehaviour
{
    public static GameEventManager instance { get; private set; }

    public Event_PlayerDead playerDead;
    public Event_PlayerDmged playerDmged;
    public Event_SmallMtaken smallMtaken;
    public Event_BigMtaken bigMtaken;
    public Event_PlayerMoving playerMoving;
    public Event_PlayerAttack playerAttack;
    public Event_EndLevel endLevel;
    public Event_EnemyDestroyed enemyDestroyed;
    public Event_StardDownLevel stardDownLevel;
    public Event_StartUpLevel startUpLevel;
    public Event_FreezeCam freezeCam;
    public Event_coin coinGain;
    public Event_MaterialPickedUp materialPickedUp;
    public Event_EndSimulationSM endSimulationSM;

    private void Awake()
    {
        instance = this;

        endSimulationSM = new Event_EndSimulationSM();
        materialPickedUp = new Event_MaterialPickedUp();
        enemyDestroyed = new Event_EnemyDestroyed();
        playerDead = new Event_PlayerDead();
        playerDmged = new Event_PlayerDmged();
        smallMtaken = new Event_SmallMtaken();
        bigMtaken = new Event_BigMtaken();
        playerMoving = new Event_PlayerMoving();
        playerAttack = new Event_PlayerAttack();
        endLevel = new Event_EndLevel();
        stardDownLevel = new Event_StardDownLevel();
        startUpLevel = new Event_StartUpLevel();
        freezeCam = new Event_FreezeCam();
        coinGain = new Event_coin();

        
    }
}
