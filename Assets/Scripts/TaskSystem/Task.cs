using System.Collections;
using System.Collections.Generic;
using CoinPackage.Debugging;
using TaskSystem;
using UnityEngine;

public class Task {
    public TaskDefinition info;

    public TaskState state;
    private int currStepIdx;
    private TaskStepState[] taskStepStates;
    public Task(TaskDefinition taskInfo) {
        this.info = taskInfo;
        this.state = TaskState.REQUIREMENTS_NOT_MET;
        this.currStepIdx = 0;
        this.taskStepStates = new TaskStepState[info.taskStepPrefabs.Length];
        for (int i = 0; i < taskStepStates.Length; i++) {
            taskStepStates[i] = new TaskStepState();
        }
    }

    public void MoveToNextStep() {
        currStepIdx++;
    }

    public bool StepExist() {
        if (currStepIdx < info.taskStepPrefabs.Length) return true;
        return false;
    }
    
    public void InstantiateTaskStep(Transform parentTransform) {
        GameObject taskStepPrefab = GetStepPrefab();
        if (taskStepPrefab is not null) {
            TaskStep taskStep = Object.Instantiate<GameObject>(taskStepPrefab, parentTransform).GetComponent<TaskStep>();
            taskStep.InitTaskStep(info.id, currStepIdx);
        }
    }

    private GameObject GetStepPrefab() {
        GameObject stepPrefab = null;
        if (StepExist()) {
            stepPrefab = info.taskStepPrefabs[currStepIdx];
        }
        else {
            CDebug.LogWarning("Wanted to get prefab of task step, but stepIndex was out of range so current step doesn't exist! TaskId="+info.id+"  stepIdx=" + currStepIdx);
        }
        return stepPrefab;
    }

    public void StoreTaskStepState(TaskStepState taskStepState, int stepIdx) {
        if (stepIdx < taskStepStates.Length) {
            taskStepStates[stepIdx].state = taskStepState.state;
            taskStepStates[stepIdx].status = taskStepState.status;
            
        }
        else {
            CDebug.LogWarning("Wanted to access task step data, but idx went out of range! TaskID: " + info.id + ", idx: " + stepIdx);
        }
    }
    public TaskData GetTaskData() {
        return new TaskData(state, currStepIdx, taskStepStates);
    }

    public string GetFullStatus() {
        string fullStatus = "";
        
        for (int i = 0; i < currStepIdx; i++) {
            fullStatus += "<s>" + taskStepStates[i].status + "</s>\n";
        }

        if (StepExist()) {
            fullStatus += taskStepStates[currStepIdx].status;
        }

        return fullStatus;
    }
}
