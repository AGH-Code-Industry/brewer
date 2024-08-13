using System.Collections.Generic;
using CoinPackage.Debugging;
using DataPersistence;
using DataPersistence.Data;
using Settings;
using TaskSystem;
using UnityEngine;
using TMPro;

public class TaskManager : MonoBehaviour, IDataPersistence {
    [Header("Content")]
    [SerializeField] private GameObject contentParent;
    [Header("Task Prefab")]
    [SerializeField] private GameObject taskPrefab;
    
    private Dictionary<string, Task> taskMap;
    private int currPlayerLevel;
    private void Awake() {
        LoadPersistentData(DataPersistenceManager.I.gameData);
    }

    private void OnEnable() {
        EventsManager.instance.taskEvents.onTaskStart += StartTask;
        EventsManager.instance.taskEvents.onTaskAdvance += AdvanceTask;
        EventsManager.instance.taskEvents.onTaskFinish += FinishTask;
        EventsManager.instance.playerEvents.onPlayerLevelChange += PlayerLevelChange;
        EventsManager.instance.taskEvents.onTaskStepStateChange += TaskStepStateChange;
    }
    private void OnDisable() {
        EventsManager.instance.taskEvents.onTaskStart -= StartTask;
        EventsManager.instance.taskEvents.onTaskAdvance -= AdvanceTask;
        EventsManager.instance.taskEvents.onTaskFinish -= FinishTask;
        EventsManager.instance.playerEvents.onPlayerLevelChange -= PlayerLevelChange;
        EventsManager.instance.taskEvents.onTaskStepStateChange -= TaskStepStateChange;
    }

    private void PlayerLevelChange(int lvl) {
        currPlayerLevel = lvl;
    }

    //starting at true and proving to be false!
    private bool AreRequirementsMet(Task task) {
        bool isOk = true;
        
        // lvl check
        if (currPlayerLevel < task.info.levelRequirement) isOk = false;
        
        //required task check
        foreach (TaskDefinition requiredTaskInfo in task.info.requiredTasks) {
            if (GetTaskById(requiredTaskInfo.id).state != TaskState.FINISHED) {
                isOk = false;
                break;
            }
        }
        return isOk;
    }

    private void Update() {
        foreach (Task task in taskMap.Values) {
            if(task.state == TaskState.REQUIREMENTS_NOT_MET && AreRequirementsMet(task)) {
                ChangeTaskState(task.info.id, TaskState.CAN_START);
            }
        }
    }

    private void ChangeTaskState(string id, TaskState state) {
        Task task = GetTaskById(id);
        task.state = state;
        EventsManager.instance.taskEvents.TaskStateChange(task);
    }

    private void TaskButton(Task task, string todo) {
        if (todo == "create") {
            GameObject taskUI = Instantiate(taskPrefab, contentParent.transform);
            taskUI.gameObject.name = task.info.id + "_button";
            taskUI.GetComponent<TaskUI>().SetTaskButton(task.info.displayName, task.GetFullStatus());
        }
        else if (todo == "update") {
            GameObject taskUI = GameObject.Find(task.info.id + "_button");
            taskUI.GetComponent<TaskUI>().SetTaskButton(task.info.displayName, task.GetFullStatus());
        }
        else if (todo == "delete") {
            GameObject taskUI = GameObject.Find(task.info.id + "_button");
            Destroy(taskUI);
        }
    }
    private void StartTask(string id) {
        Task task = GetTaskById(id);
        task.InstantiateTaskStep(this.transform);
        ChangeTaskState(task.info.id, TaskState.IN_PROGRESS);
        TaskButton(task, "create");
        CDebug.Log("Task start: " + id);
    }
    // ReSharper disable Unity.PerformanceAnalysis
    private void AdvanceTask(string id) {
        Task task = GetTaskById(id);
        task.MoveToNextStep();
        
        if (task.StepExist()) {
            task.InstantiateTaskStep(this.transform);
        }
        else {
            if (task.info.autoFinish == false) {
                ChangeTaskState(task.info.id, TaskState.CAN_FINISH);
            }
            else {
                EventsManager.instance.taskEvents.TaskFinish(id);
            }
            
        }
        TaskButton(task, "update");
        CDebug.Log("Task advance: " + id);
    }
    private void FinishTask(string id) {
        Task task = GetTaskById(id);
        TaskButton(task, "delete");
        ClaimRewards(task);
        ChangeTaskState(task.info.id, TaskState.FINISHED);
        if (task.info.startNextTasks.Length > 0) {
            foreach (TaskDefinition tasks in task.info.startNextTasks) {
                EventsManager.instance.taskEvents.TaskStart(tasks.id);
            }
        }
        CDebug.Log("Task finish: " + id);
    }

    private void ClaimRewards(Task task) {
        EventsManager.instance.playerEvents.ExpAdd(task.info.expReward);
    }
    
    private void Start() {
        //broadcast the init state of all tasks at start 
        foreach (Task task in taskMap.Values) {
            if (task.state == TaskState.IN_PROGRESS) {
                task.InstantiateTaskStep(this.transform);
            }
            EventsManager.instance.taskEvents.TaskStateChange(task);
        }
    }

    private void TaskStepStateChange(string id, int stepIdx, TaskStepState taskStepState) {
        Task task = GetTaskById(id);
        task.StoreTaskStepState(taskStepState,stepIdx);
        ChangeTaskState(id, task.state);
        TaskButton(task, "update");
    }
    
    private Dictionary<string, Task> CreateTaskMap() {
        TaskDefinition[] allTasks = Resources.LoadAll<TaskDefinition>("Tasks");
        Dictionary<string, Task> idToTaskMap = new Dictionary<string, Task>();
        foreach (TaskDefinition taskInfo in allTasks) {
            if (idToTaskMap.ContainsKey(taskInfo.id)) {
                CDebug.LogWarning("Found duplicated id while initializing task map: " + taskInfo.id);
            }
            idToTaskMap.Add(taskInfo.id, new Task(taskInfo));
        }
        return idToTaskMap;
    }

    public Task GetTaskById(string id) {
        Task task = taskMap[id];
        if(task is null) CDebug.LogError("ID not in task map: " + id);
        return task;
    }

    private void OnApplicationQuit() {
        DataPersistenceManager.I.SaveGame(DevSet.I.appSettings.defaultSaveName);
    }
    
    public void LoadPersistentData(GameData gameData) {
        if (gameData.taskData.tasks.Count == 0) {
            taskMap = CreateTaskMap();
            return;
        }
        TaskDefinition[] allTasks = Resources.LoadAll<TaskDefinition>("Tasks");
        Dictionary<string, Task> idToTaskMap = new Dictionary<string, Task>();
        List<string> allId = new List<string>();
        for (int i = 0; i < gameData.taskData.tasks.Count; i++) {
            allId.Add(gameData.taskData.tasks[i].id);
        }
        var tasks = 0;
        foreach (TaskDefinition taskInfo in allTasks) {
            if (idToTaskMap.ContainsKey(taskInfo.id)) {
                CDebug.LogWarning("Found duplicated id while initializing task map: " + taskInfo.id);
            }
            Task newTask = null;
            
            if(allId.Contains(taskInfo.id)) {
                TaskEntry taskEntry = gameData.taskData.tasks[allId.IndexOf(taskInfo.id)];
                newTask = new Task(taskInfo, taskEntry.state, taskEntry.taskStepIdx, taskEntry.taskStepStates);
            }
            else {
                newTask = new Task(taskInfo);
            }
            idToTaskMap.Add(taskInfo.id, newTask);
            if (newTask.state == TaskState.IN_PROGRESS) {
                TaskButton(newTask, "create");
            }
            tasks++;
        }
        taskMap = idToTaskMap;
        CDebug.Log($"Loaded {tasks % Colorize.Cyan} from the save.");
    }

    public void SavePersistentData(ref GameData gameData) {
        List<TaskEntry> tasksToSave = new List<TaskEntry>();
        foreach (Task task in taskMap.Values) {
            tasksToSave.Add(task.GetTaskData());
        }
        CDebug.Log($"Saved {tasksToSave.Count % Colorize.Cyan} tasks to the save.");
        gameData.taskData.tasks = tasksToSave;
    }
}
