using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


[System.Serializable]
public class TaskEntry {
    public string id;
    public TaskState state;
    public int taskStepIdx;
    public TaskStepState[] taskStepStates;

    public TaskEntry(string id, TaskState state, int taskStepIdx, TaskStepState[] taskStepStates) {
        this.id = id;
        this.state = state;
        this.taskStepIdx = taskStepIdx;
        this.taskStepStates = taskStepStates;
    }
}
