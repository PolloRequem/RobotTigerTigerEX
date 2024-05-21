using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Event_coin 
{

    public static Event_coin current;
    public event Action onCoinGained;

    public void CoinGained()
    {

        onCoinGained?.Invoke();
    }
}
