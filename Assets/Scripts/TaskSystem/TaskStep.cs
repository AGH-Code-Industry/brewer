using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoinPackage.Debugging;

public abstract class TaskStep : MonoBehaviour {
    private bool isFinished = false;
    private string taskId;
    private int stepIdx;

    public void InitTaskStep(string taskId, int stepIdx) {
        this.taskId = taskId;
        this.stepIdx = stepIdx;
    }
    
    protected void FinishTaskStep() {
        if (!isFinished) {
            isFinished = true;
            EventsManager.instance.taskEvents.TaskAdvance(taskId);
            Destroy(this.gameObject);
        }
    }

    protected void ChangeState(string newState, string newStatus) {
        EventsManager.instance.taskEvents.TaskStepStateChange(taskId, stepIdx, new TaskStepState(newState, newStatus));
    }
    
}
