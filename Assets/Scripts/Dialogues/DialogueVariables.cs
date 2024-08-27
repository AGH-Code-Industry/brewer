using System.Collections.Generic;
using CoinPackage.Debugging;
using DataPersistence;
using DataPersistence.Data;
using Ink.Runtime;
using Settings;
using UnityEngine;


public class DialogueVariables : MonoBehaviour, IDataPersistence {
    [SerializeField] private TextAsset loadGlobalsJSON;
    public Dictionary<string, Ink.Runtime.Object> variables { get; private set; }

    private Story globalVariablesStory;

    public void Awake() {
        globalVariablesStory = new Story(loadGlobalsJSON.text);
        LoadPersistentData(DataPersistenceManager.I.gameData);
    }
    public void StartListening(Story story) {
        VariablesToStory(story);
        story.variablesState.variableChangedEvent += VariableChanged;
    }
    public void StopListening(Story story) {
        story.variablesState.variableChangedEvent -= VariableChanged;
    }
    
    
    private void VariableChanged(string name, Ink.Runtime.Object value) {
        if (variables.ContainsKey(name)) {
            variables.Remove(name);
            variables.Add(name, value);
        }
    }

    private void VariablesToStory(Story story) {
        foreach (KeyValuePair<string,Ink.Runtime.Object> variable in variables) {
            story.variablesState.SetGlobal(variable.Key, variable.Value);
        }
    }

    public void LoadPersistentData(GameData gameData) {
        if (gameData.inkData != "") {
            globalVariablesStory.state.LoadJson(gameData.inkData);
        }
        variables = new Dictionary<string, Ink.Runtime.Object>();
        foreach (string name in globalVariablesStory.variablesState) {
            Ink.Runtime.Object value = globalVariablesStory.variablesState.GetVariableWithName(name);
            variables.Add(name,value);
        }
        if (gameData.inkData != "") {
            CDebug.Log($"Loaded {variables.Count % Colorize.Cyan} Ink Variables from save.");
        }
    }

    public void SavePersistentData(ref GameData gameData) {
        VariablesToStory(globalVariablesStory);
        CDebug.Log($"Saved {variables.Count % Colorize.Cyan} Ink Variables to the save.");
        gameData.inkData = globalVariablesStory.state.ToJson();
    }
}
