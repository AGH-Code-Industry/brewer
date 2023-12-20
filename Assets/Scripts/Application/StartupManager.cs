using System.Collections;
using System.Collections.Generic;
using Settings;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Application {
    public class StartupManager : MonoBehaviour
    {
        private void Start() {
            SceneManager.LoadScene(DevSet.I.appSettings.firstSceneName, LoadSceneMode.Single);
        }
    }
}

