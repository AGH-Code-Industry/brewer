using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class ExternalFunctions
{
    
    //REMEMBER! When defining new external function ALWAYS put UnbindExternalFunction method accordingly
    //inside Unbind function!
    //Also don't hesitate to add more parameters to Bind function, but remember to add them in 
    //DialogueManager.cs file!
    public void Bind(Story story, TaskManager taskManager) {
        story.BindExternalFunction("getTaskState", (string taskID) => {
            string state = taskManager.GetTaskById(taskID).state.ToString();
            return state;
        });
        story.BindExternalFunction("finishTask", (string taskID) => {
            EventsManager.instance.taskEvents.TaskFinish(taskID);
        });
    }

    public void Unbind(Story story) {
        story.UnbindExternalFunction("getTaskState");
        story.UnbindExternalFunction("finishTask");
    }
}
