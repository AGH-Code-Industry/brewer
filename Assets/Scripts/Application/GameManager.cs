using System.Collections;
using System.Collections.Generic;
using DataPersistence;
using Settings;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils.Globals;
using Utils.Singleton;

namespace Application {
    public class GameManager : Singleton<GameManager>
    {
        void Start()
        {
            // Load scene based on save
            switch (DataPersistenceManager.I.GameData.currentPlace) {
                case PlaceType.Dormitory:
                    SceneManager.LoadScene(DevSet.I.appSettings.dormitorySceneName, LoadSceneMode.Additive);
                    break;
                case PlaceType.Town:
                    SceneManager.LoadScene(DevSet.I.appSettings.townSceneName, LoadSceneMode.Additive);
                    break;
            }
        }
    }
}
