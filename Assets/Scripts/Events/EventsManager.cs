using System;
using System.Collections;
using System.Collections.Generic;
using CoinPackage.Debugging;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    public static EventsManager instance { get; private set; }

    public TaskEvents taskEvents;
    public InputEvents inputEvents;
    public PlayerEvents playerEvents;

    private void Awake() {
        if (instance is not null) {
            CDebug.LogError("There are multiple Events Managers on the scene!");
        }

        instance = this;

        taskEvents = new TaskEvents();
        inputEvents = new InputEvents();
        playerEvents = new PlayerEvents();
        
    }
}
