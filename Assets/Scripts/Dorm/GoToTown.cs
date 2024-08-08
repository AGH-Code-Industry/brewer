using System.Collections;
using System.Collections.Generic;
using Application;
using UnityEngine;
using UnityEngine.SceneManagement;
using Settings;
public class GoToTown : MonoBehaviour
{
    public void OnPress() {
        SceneManager.UnloadSceneAsync(DevSet.I.appSettings.dormitorySceneName);
        SceneManager.LoadScene(DevSet.I.appSettings.townSceneName, LoadSceneMode.Additive);
    }
}
