using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Event_EndSimulationSM 
{  
    public static Event_EndSimulationSM current;
    public event Action onEndSimulationSM;

    public void EndSim()
    {
       onEndSimulationSM?.Invoke();
    }
}
