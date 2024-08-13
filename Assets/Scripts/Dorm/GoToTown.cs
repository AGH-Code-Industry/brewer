using System.Collections;
using System.Collections.Generic;
using Application;
using DataPersistence;
using UnityEngine;
using UnityEngine.SceneManagement;
using Settings;
public class GoToTown : MonoBehaviour
{
    public void OnPress() {
        DataPersistenceManager.I.SaveGame(DevSet.I.appSettings.defaultSaveName);
        SceneManager.UnloadSceneAsync(DevSet.I.appSettings.dormitorySceneName);
        SceneManager.LoadScene(DevSet.I.appSettings.townSceneName, LoadSceneMode.Additive);
    }
}
