using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Event_BigMtaken 
{
    public static Event_BigMtaken current;
    public event Action onBigMtaken;
 
    public void BingMtaken()
    {
        onBigMtaken?.Invoke();
    }
}
