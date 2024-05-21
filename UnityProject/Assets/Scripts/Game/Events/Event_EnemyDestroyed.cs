using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Event_EnemyDestroyed 
{
    public static Event_EnemyDestroyed current;
    public event Action onEnemyDestroyed;

    public void EnemyDestroyed()
    {
        onEnemyDestroyed?.Invoke();
    }
}
