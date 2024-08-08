using System;
using System.Collections;
using System.Collections.Generic;
using CoinPackage.Debugging;
using DataPersistence;
using DataPersistence.Data;
using TaskSystem;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.PackageManager;

public class TaskManager : MonoBehaviour, IDataPersistence {
    [Header("Content")]
    [SerializeField] private GameObject contentParent;
    [Header("Task Prefab")]
    [SerializeField] private GameObject taskPrefab;
    
    private Dictionary<string, Task> taskMap;
    private int currPlayerLevel;
    private void Awake() {
        taskMap = CreateTaskMap();
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
    
    private void StartTask(string id) {
        Task task = GetTaskById(id);
        task.InstantiateTaskStep(this.transform);
        ChangeTaskState(task.info.id, TaskState.IN_PROGRESS);
        GameObject taskUI = Instantiate(taskPrefab, contentParent.transform);
        taskUI.gameObject.name = task.info.id + "_button";
        Transform taskName = taskUI.transform.GetChild(0);
        taskName.GetComponent<TMP_Text>().text = task.info.displayName;
        Transform taskDesc = taskUI.transform.GetChild(1);
        taskDesc.GetComponent<TMP_Text>().text = task.GetFullStatus();
        CDebug.Log("Task start: " + id);
    }
    // ReSharper disable Unity.PerformanceAnalysis
    private void AdvanceTask(string id) {
        Task task = GetTaskById(id);
        GameObject taskUI = GameObject.Find(task.info.id + "_button");
        Transform taskDesc = taskUI.transform.GetChild(1);
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
        taskDesc.GetComponent<TMP_Text>().text = task.GetFullStatus();
        CDebug.Log("Task advance: " + id);
    }
    private void FinishTask(string id) {
        Task task = GetTaskById(id);
        GameObject taskUI = GameObject.Find(task.info.id + "_button");
        Destroy(taskUI);
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
            EventsManager.instance.taskEvents.TaskStateChange(task);
        }
    }

    private void TaskStepStateChange(string id, int stepIdx, TaskStepState taskStepState) {
        Task task = GetTaskById(id);
        task.StoreTaskStepState(taskStepState,stepIdx);
        ChangeTaskState(id, task.state);
        GameObject taskUI = GameObject.Find(task.info.id + "_button");
        Transform taskDesc = taskUI.transform.GetChild(1);
        taskDesc.GetComponent<TMP_Text>().text = task.GetFullStatus();
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
        foreach (Task task in taskMap.Values) {
            TaskData taskData = task.GetTaskData();
            string teststate = "state = " + taskData.state;
            string testidx = "idx = " + taskData.taskStepIdx;
            string teststeps = "";
            foreach (TaskStepState stepState in taskData.taskStepStates) {
                teststeps += "   step state = " + stepState.state;
            }

            CDebug.Log(teststate + " " + testidx + " " + teststeps);
        }
    }
    
    public void LoadPersistentData(GameData gameData) {
        // if (gameData.inventoryData.items.Count == 0) return;
        //     
        // _items.Clear();
        // var assets = Resources.LoadAll(DevSet.I.appSettings.itemsResPath);
        // var items = 0;
        // var count = 0;
        // foreach (var item in gameData.inventoryData.items) {
        //     var asset = (ItemDefinition)assets.First(asset => asset.name == item.assetName);
        //     InsertItem(asset, item.quantity);
        //     items++;
        //     count += item.quantity;
        // }
        // _logger.Log($"Loaded {items % Colorize.Cyan} from the save, total count: {count % Colorize.Magenta}.");
        // inventoryUpdated?.Invoke();
    }

    public void SavePersistentData(ref GameData gameData) {
        // List<InventoryEntry> itemsToSave = new List<InventoryEntry>();
        // var count = 0;
        // foreach (var (key, value) in _items) {
        //     itemsToSave.Add(new InventoryEntry(key.name, value));
        //     count += value;
        // }
        // _logger.Log($"Saved {itemsToSave.Count % Colorize.Cyan} to the save, total count: {count % Colorize.Magenta}.");
        // gameData.inventoryData.items = itemsToSave;
    }
}
