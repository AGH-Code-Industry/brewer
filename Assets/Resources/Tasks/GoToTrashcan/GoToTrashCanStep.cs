using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToTrashCanStep : TaskStep {
    private void Start() {
        string status = "Wciśnij \"L\" na klawiaturze";
        UpdateState(status);
    }
    void Update() {
        if (Input.GetKeyDown(KeyCode.L)) {
            string status = "Wciśnięto \"L\" na klawiaturze!";
            UpdateState(status);
            FinishTaskStep();
        }
    }
    
    
    // ReSharper disable Unity.PerformanceAnalysis
    private void UpdateState(string status) {
        ChangeState("",status);
    }
}
