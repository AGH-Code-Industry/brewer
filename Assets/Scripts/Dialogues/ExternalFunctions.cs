using System;
using System.Collections;
using System.Collections.Generic;
using CoinPackage.Debugging;
using UnityEngine;
using Ink.Runtime;
using TaskSystem;

public class ExternalFunctions
{
    
    //REMEMBER! When defining new external function ALWAYS put UnbindExternalFunction method accordingly
    //inside Unbind function!
    //Also don't hesitate to add more parameters to Bind function, but remember to add them in 
    //DialogueManager.cs file!
    public void Bind(Story story) {
        story.BindExternalFunction("getTaskState", (string taskID) => {
            string state = EventsManager.instance.taskManager.GetTaskById(taskID).state.ToString();
            return state;
        });
        story.BindExternalFunction("finishTask", (string taskID) => {
            EventsManager.instance.taskEvents.TaskFinish(taskID);
        });
        story.BindExternalFunction("startOrderFromSO", (string name) => {
            var orderDef = Resources.Load<OrderDefinition>("Orders/" + name);
            if (orderDef is null) {
                CDebug.LogError("OrderDefinition of name \"" + name + "\" doesn't exist at path \"Resources/Orders\"! Not starting any order!");
                return;
            }
            else {
                EventsManager.instance.orderEvents.OrderStart(new Order(orderDef));
            }
        });
        story.BindExternalFunctionGeneral("startOrderFromScratch", (object[] parameters) => {
            // <name_of_beer>:<quantity>/<name_of_beer>:<quantity>
            string[] orderDetails = parameters[3].ToString().Split("/");
            List<OrderEntry> orders = new List<OrderEntry>();
            foreach (string part in orderDetails) {
                string[] splittedPart = part.Split(":");
                orders.Add(new OrderEntry(EventsManager.instance.orderManager.GetItemByName(splittedPart[0]),Int32.Parse(splittedPart[1])));
            }
            Order order = new Order(parameters[0].ToString(), parameters[1].ToString(),parameters[2].ToString(),orders,Int32.Parse(parameters[4].ToString()),Int32.Parse(parameters[5].ToString()),Int32.Parse(parameters[6].ToString()),Int32.Parse(parameters[7].ToString()));
            EventsManager.instance.orderEvents.OrderStart(order);
            return null;
        });
        story.BindExternalFunction("finishOrder", (string name) => {
            Dictionary<string, Order> map = EventsManager.instance.orderManager.orderMap;
            List<string> IDs = new List<string>();
            foreach (Order order in map.Values) {
                if (order.clientName == name) IDs.Add(order.id);
            }
            if (IDs.Count > 1) {
                CDebug.LogError(name + " has over one active order in orderMap. Determining which order needs to be finished isn't yet implemented. Operation aborted!");
                return "MORE_THAN_ONE_ERROR";
            }
            if (IDs.Count == 0) {
                CDebug.LogError(name + " has no active orders in orderMap.");
                return "NO_ORDER_ERROR";
            }
            EventsManager.instance.orderEvents.OrderFinish(IDs[0], true);
            return "0";
        });
    }

    public void Unbind(Story story) {
        story.UnbindExternalFunction("getTaskState");
        story.UnbindExternalFunction("finishTask");
        story.UnbindExternalFunction("startOrderFromSO");
        story.UnbindExternalFunction("startOrderFromScratch");
        story.UnbindExternalFunction("finishOrder");
    }
}
