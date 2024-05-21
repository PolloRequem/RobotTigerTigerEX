using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHPManager : MonoBehaviour
{
    private float player_hp = 3;

    private void Start()
    {
        GameEventManager.instance.playerDmged.onPlayerDmged += PlayerDmged_onPlayerDmged;
    }

    private void PlayerDmged_onPlayerDmged()
    {
        player_hp--;

        if (player_hp <= 0)
        {
            GameEventManager.instance.playerDead.PlayerDead();
        }
    }
}
