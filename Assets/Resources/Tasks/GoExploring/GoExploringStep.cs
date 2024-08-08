using System;
using System.Collections;
using System.Collections.Generic;
using CoinPackage.Debugging;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class GoExploringStep : TaskStep {
    [Header("Config")] 
    [SerializeField] private string nameOfPlace = "nazwamiejsca";
    private void Start() {
        string status = "Podejdź do: \"" + nameOfPlace + "\"";
        UpdateState(status);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            string status = "Odwiedzono \"" + nameOfPlace + "\"";
            UpdateState(status);
            FinishTaskStep();
        }
    }
    
    
    private void UpdateState(string status) {
        string state = nameOfPlace;
        ChangeState(state,status);
    }
}
