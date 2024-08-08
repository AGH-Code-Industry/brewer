using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class TaskData {
    public TaskState state;
    public int taskStepIdx;
    public TaskStepState[] taskStepStates;

    public TaskData(TaskState state, int taskStepIdx, TaskStepState[] taskStepStates) {
        this.state = state;
        this.taskStepIdx = taskStepIdx;
        this.taskStepStates = taskStepStates;
    }
}
