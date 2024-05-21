using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Event_SmallMtaken 
{
    public static Event_SmallMtaken current;
    public event Action onSmallMtaken;

    public void SmallMtaken()
    {
        onSmallMtaken?.Invoke();
    }
}
