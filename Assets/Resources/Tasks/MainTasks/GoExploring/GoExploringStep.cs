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
        ChangeState("in_progress",status);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            string status = "Odwiedzono \"" + nameOfPlace + "\"";
            ChangeState("finished", status);
            FinishTaskStep();
        }
    }

    protected override void SetTaskStepState(string state) {
        if (state == "finished") {
            string status = "Odwiedzono \"" + nameOfPlace + "\"";
            ChangeState("finished", status);
            FinishTaskStep();
        }
        else {
            string status = "Podejdź do: \"" + nameOfPlace + "\"";
            ChangeState("in_progress",status);
        }
    }
}
