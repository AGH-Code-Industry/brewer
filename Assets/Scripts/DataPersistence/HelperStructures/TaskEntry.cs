namespace DataPersistence.HelperStructures {
    [System.Serializable]
    public class TaskEntry {
        public TaskState state;
        public int taskStepIdx;
        public TaskStepState[] taskStepStates;
        
        public TaskEntry(TaskState state, int taskStepIdx, TaskStepState[] taskStepStates) {
            this.state = state;
            this.taskStepIdx = taskStepIdx;
            this.taskStepStates = taskStepStates;
        }
    }
}