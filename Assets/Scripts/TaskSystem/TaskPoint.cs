using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CoinPackage.Debugging;
using TaskSystem;
using UnityEngine;
using UnityEngine.InputSystem;

public class TaskPoint : MonoBehaviour {

    [Header("Task")] 
    [SerializeField] private TaskDefinition taskInfoForPoint;

    [Header("Config")] 
    [SerializeField] private bool startPoint = true;
    [SerializeField] private bool finishPoint = true;
    
    private bool playerIsNear = false;
    private string taskId;
    private TaskState currTaskState;

    private void Awake() {
        taskId = taskInfoForPoint.id;
    }

    private void OnEnable() {
        EventsManager.instance.taskEvents.onTaskStateChange += TaskStateChange;
        EventsManager.instance.inputEvents.onSelectPressed += SelectPressed;
    }
    private void OnDisable() {
        EventsManager.instance.taskEvents.onTaskStateChange -= TaskStateChange;
        EventsManager.instance.inputEvents.onSelectPressed -= SelectPressed;
    }

    private void SelectPressed() {
        
        if(!playerIsNear) return;
        OrderEntry[] test = new OrderEntry[] { };
        Order order = new Order("1", true, "zbych", "5 dni", test, 50, 50, 5, 5);
        EventsManager.instance.orderEvents.OrderStart(order);
        if (currTaskState == TaskState.CAN_START && startPoint) {
            EventsManager.instance.taskEvents.TaskStart(taskId);
        }
        else if (currTaskState == TaskState.CAN_FINISH && finishPoint) {
            EventsManager.instance.taskEvents.TaskFinish(taskId);
        }
        
    }

    private void TaskStateChange(Task task) {
        if (task.info.id == taskId) {
            currTaskState = task.state;
            //CDebug.Log("Task of id: " + taskId + " updated to state: " + currTaskState);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) playerIsNear = true;
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) playerIsNear = false;
    }
}
