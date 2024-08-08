using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TasksUI : MonoBehaviour {
    [Header("Content")]
    [SerializeField] private GameObject contentParent;
    [Header("Task Prefab")]
    [SerializeField] private GameObject taskPrefab;

    [SerializeField] private TaskManager _taskManager;
    
    private void OnEnable() {
        EventsManager.instance.taskEvents.onTaskStart += StartTaskUI;
        //EventsManager.instance.taskEvents.onTaskAdvance += AdvanceTask;
        //EventsManager.instance.taskEvents.onTaskFinish += FinishTask;
        //EventsManager.instance.playerEvents.onPlayerLevelChange += PlayerLevelChange;
    }
    private void OnDisable() {
        EventsManager.instance.taskEvents.onTaskStart -= StartTaskUI;
        //EventsManager.instance.taskEvents.onTaskAdvance -= AdvanceTask;
        //EventsManager.instance.taskEvents.onTaskFinish -= FinishTask;
        //EventsManager.instance.playerEvents.onPlayerLevelChange -= PlayerLevelChange;
    }

    private void StartTaskUI(string id) {
        Task task = _taskManager.GetTaskById(id);
        GameObject taskUI = Instantiate(taskPrefab, contentParent.transform).GetComponent<GameObject>();
        TMP_Text taskName = taskUI.transform.GetChild(0).GetComponent<TMP_Text>();
        taskName.text = task.info.displayName;
    }
    
    
}
