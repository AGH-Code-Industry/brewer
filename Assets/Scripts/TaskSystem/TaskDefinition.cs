using UnityEngine;

namespace TaskSystem {
    [CreateAssetMenu(fileName = "TaskInfo", menuName = "Tasks/TaskInfo", order = 1)]
    public class TaskDefinition : ScriptableObject
    {
        [field: SerializeField] public string id { get; private set; }

        [Header("Main")] 
        public string displayName;
        public TaskType type;
    
        [Header("Requirements")] 
        public int levelRequirement;
        public TaskDefinition[] requiredTasks;

        [Header("Steps")] 
        public GameObject[] taskStepPrefabs;

        [Header("Post Finish actions")] 
        public bool autoFinish;
        public TaskDefinition[] startNextTasks;
        
        [Header("Rewards")] 
        public int moneyReward;
        public int expReward;
        private void OnValidate() {
            #if UNITY_EDITOR
            id = this.name;
            UnityEditor.EditorUtility.SetDirty(this);
            #endif
        }
    }
}
