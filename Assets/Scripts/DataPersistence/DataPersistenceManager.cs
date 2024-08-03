using System;
using System.Collections.Generic;
using System.Linq;
using CoinPackage.Debugging;
using CustomInput;
using DataPersistence.Data;
using Settings;
using UnityEngine;
using Utils;
using Utils.Singleton;

namespace DataPersistence {
    [RequireComponent(typeof(DoNotDestroy))]
    public class DataPersistenceManager : Singleton<DataPersistenceManager>
    {
        [NonSerialized]
        public GameData gameData;

        private readonly CLogger _logger = Loggers.LoggersList[Loggers.LoggerType.DATA_PERSISTENCE];
        private List<IDataPersistence> _persistentObjects;
        private FileDataHandler _fileDataHandler;

        private void Start() {
            _fileDataHandler = new FileDataHandler(UnityEngine.Application.persistentDataPath + "/Saves");
            
            //TODO: Remove
            CInput.InputActions.Testing.SaveGame.performed += _ => SaveGame(DevSet.I.appSettings.defaultSaveName);
        }

        public void CreateNewGame() {
            gameData = new GameData();
        }

        public void LoadSave(string saveName) {
            gameData = _fileDataHandler.Load(saveName);
        }

        public void SaveGame(string saveName) {
            SavePersistentObjects();
            gameData.isNewSave = false;
            _fileDataHandler.Save(gameData, saveName);
        }

        private void SavePersistentObjects() {
            foreach (var persistentObject in FindPersistentObjects()) {
                persistentObject.SavePersistentData(ref gameData);
            }
        }
        
        private List<IDataPersistence> FindPersistentObjects() {
            IEnumerable<IDataPersistence> persistentObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();
            return new List<IDataPersistence>(persistentObjects);
        }
    }
}
