using System;
using System.Collections;
using System.Collections.Generic;
using CoinPackage.Debugging;
using Unity.VisualScripting;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    public static EventsManager instance { get; private set; }

    public TaskEvents taskEvents;
    public InputEvents inputEvents;
    public PlayerEvents playerEvents;
    public OrderEvents orderEvents;

    private void Awake() {
        if (instance is not null) {
            CDebug.LogError("There are multiple Events Managers on the scene! Destroying the newest one.");
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);

        taskEvents = new TaskEvents();
        inputEvents = new InputEvents();
        playerEvents = new PlayerEvents();
        orderEvents = new OrderEvents();
        
    }
}
