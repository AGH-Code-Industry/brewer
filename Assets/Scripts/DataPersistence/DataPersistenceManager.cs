using System;
using System.Collections.Generic;
using System.Linq;
using CoinPackage.Debugging;
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
        public GameData GameData;

        private readonly CLogger _logger = Loggers.LoggersList[Loggers.LoggerType.DATA_PERSISTENCE];
        private FileDataHandler _fileDataHandler;
        
        private void Start() {
            _fileDataHandler = new FileDataHandler(UnityEngine.Application.dataPath);
        }

        public void CreateNewGame() {
            GameData = new GameData();
        }

        public void LoadSave(string saveName) {
            GameData = _fileDataHandler.Load(saveName);
        }

        public void SaveGame(string saveName) {
            _fileDataHandler.Save(GameData, saveName);
        }

        private List<IDataPersistence> FindPersistentObjects() {
            IEnumerable<IDataPersistence> persistentObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();
            return new List<IDataPersistence>(persistentObjects);
        }
    }
}
