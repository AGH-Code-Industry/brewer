﻿using System;
using System.IO;
using CoinPackage.Debugging;
using UnityEngine;
using Utils;

namespace DataPersistence {
    public class FileDataHandler {
        private readonly string _saveDirectory;
        private readonly string _saveFileName;

        private readonly CLogger _logger = Loggers.LoggersList[Loggers.LoggerType.DATA_PERSISTENCE];

        public FileDataHandler(string saveDirectory, string saveFileName) {
            _saveDirectory = saveDirectory;
            _saveFileName = saveFileName;
        }

        public bool Save(GameData gameData) {
            var filePath = Path.Combine(_saveDirectory, _saveFileName);
            try {
                Directory.CreateDirectory(_saveDirectory);
                var data = JsonUtility.ToJson(gameData);

                using (FileStream stream = new FileStream(filePath, FileMode.Create)) {
                    using (StreamWriter writer = new StreamWriter(stream)) {
                        writer.Write(data);
                    }
                }
                _logger.Log($"Saved game data to file: {filePath}");
            }
            catch (Exception e) {
                _logger.LogError($"Error trying to save data to {filePath}: {e.Message}");
                return false;
            }

            return true;
        }

        public GameData Load() {
            var filePath = Path.Combine(_saveDirectory, _saveFileName);

            if (File.Exists(filePath)) {
                try {
                    var dataToLoad = "";
                    using (FileStream stream = new FileStream(filePath, FileMode.Open)) {
                        using (StreamReader reader = new StreamReader(stream)) {
                            dataToLoad = reader.ReadToEnd();
                        }
                    }
                    return JsonUtility.FromJson<GameData>(dataToLoad);
                }
                catch (Exception e) {
                    throw new Exception($"Error reading file {e.Message}");
                }
            }
            else {
                throw new Exception("Save file does not exist");
            }
        }
    }
}