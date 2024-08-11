using System.Collections;
using System.Collections.Generic;
using Application;
using DataPersistence;
using UnityEngine;
using UnityEngine.SceneManagement;
using Settings;
public class GoToDorm : MonoBehaviour
{
    private bool playerIsNear = false;
    private void OnEnable() {
        EventsManager.instance.inputEvents.onSelectPressed += SelectPressed;
    }
    private void OnDisable() {
        EventsManager.instance.inputEvents.onSelectPressed -= SelectPressed;
    }
    public void SelectPressed() {
        if(!playerIsNear) return;
        DataPersistenceManager.I.SaveGame(DevSet.I.appSettings.defaultSaveName);
        SceneManager.UnloadSceneAsync(DevSet.I.appSettings.townSceneName);
        SceneManager.LoadScene(DevSet.I.appSettings.dormitorySceneName, LoadSceneMode.Additive);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) playerIsNear = true;
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) playerIsNear = false;
    }
}
