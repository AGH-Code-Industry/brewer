using System;

public class TaskEvents {
    public event Action<string> onTaskStart;
    public event Action<string> onTaskAdvance;
    public event Action<string> onTaskFinish;
    public event Action<Task> onTaskStateChange;
    public event Action<string, int, TaskStepState> onTaskStepStateChange;

    public void TaskStart(string id) {
        if (onTaskStart is not null) {
            onTaskStart(id);
        }
    }
    public void TaskAdvance(string id) {
        if (onTaskAdvance is not null) {
            onTaskAdvance(id);
        }
    }
    public void TaskFinish(string id) {
        if (onTaskFinish is not null) {
            onTaskFinish(id);
        }
    }
    public void TaskStateChange(Task task) {
        if (onTaskStateChange is not null) {
            onTaskStateChange(task);
        }
    }
    
    public void TaskStepStateChange(string id, int stepIdx, TaskStepState taskStepState) {
        if (onTaskStepStateChange is not null) {
            onTaskStepStateChange(id, stepIdx, taskStepState);
        }
    }
}
